namespace Auction.Application.Extensions;

/// <summary>
/// Extension class for configuring application services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds application-specific services to the dependency injection container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddHostedService<AuctionBackgroundService>();
    }
}
