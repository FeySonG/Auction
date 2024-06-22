using Microsoft.Extensions.Hosting;

namespace Auction.Application.BackGroundServices;

/// <summary>
/// Background service to handle auction updates.
/// </summary>
public class AuctionBackgroundService(IServiceProvider serviceProvider) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    /// <summary>
    /// Executes the background service.
    /// </summary>
    /// <param name="stoppingToken">Token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the execution of the service.</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auctionRepository = scope.ServiceProvider.GetRequiredService<IProductAuctionRepository>();
                var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
                var serviceAuctionRepository = scope.ServiceProvider.GetRequiredService<IServiceAuctionRepository>();
                var serviceRepository = scope.ServiceProvider.GetRequiredService<IServiceLayerRepository>();
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                await UpdateProductWinnersAsync(auctionRepository, productRepository, userRepository, uow);
                await UpdateServiceWinnersAsync(serviceAuctionRepository, serviceRepository, userRepository, uow);
            }

            // Waits 1 minute before the next check
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }

    /// <summary>
    /// Updates the winners of product auctions.
    /// </summary>
    /// <param name="auctionRepository">The product auction repository.</param>
    /// <param name="productRepository">The product repository.</param>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="uow">The unit of work.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    private async Task UpdateProductWinnersAsync(
        IProductAuctionRepository auctionRepository,
        IProductRepository productRepository,
        IUserRepository userRepository,
        IUnitOfWork uow)
    {
        var auctions = await auctionRepository.GetAllAsync();
        var finishedAuctions = auctions.Where(a => a.EndTime <= DateTime.UtcNow).ToList();

        foreach (var auction in finishedAuctions)
        {
            var product = await productRepository.GetById(auction.ProductId);
            if (product != null)
            {
                var winnerExists = await userRepository.ExistsAsync(auction.CurrentWinnerId);
                if (winnerExists)
                {
                    product.OwnerId = auction.CurrentWinnerId;
                    productRepository.Update(product);
                }
            }
        }

        auctionRepository.RemoveRange(finishedAuctions);
        await uow.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the winners of service auctions.
    /// </summary>
    /// <param name="serviceAuctionRepository">The service auction repository.</param>
    /// <param name="serviceRepository">The service repository.</param>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="uow">The unit of work.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    private async Task UpdateServiceWinnersAsync(
        IServiceAuctionRepository serviceAuctionRepository,
        IServiceLayerRepository serviceRepository,
        IUserRepository userRepository,
        IUnitOfWork uow)
    {
        var auctions = await serviceAuctionRepository.GetAllAsync();
        var finishedAuctions = auctions.Where(a => a.EndTime <= DateTime.UtcNow).ToList();

        foreach (var auction in finishedAuctions)
        {
            var service = await serviceRepository.GetById(auction.ServiceId);
            if (service != null)
            {
                var winnerExists = await userRepository.ExistsAsync(auction.CurrentWinnerId);
                if (winnerExists)
                {
                    service.OwnerId = auction.CurrentWinnerId;
                    serviceRepository.Update(service);
                }
            }
        }

        serviceAuctionRepository.RemoveRange(finishedAuctions);
        await uow.SaveChangesAsync();
    }
}
