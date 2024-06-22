using Microsoft.Extensions.Hosting;

namespace Auction.Application.BackGroundServices
{
    public class AuctionBackgroundService(IServiceProvider serviceProvider) : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

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

                // Ждем 1 минуту перед следующей проверкой
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

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
}

