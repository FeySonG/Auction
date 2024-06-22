namespace Auction.DAL.Extensions;

public static class DependencyInjection
{
    public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(nameof(AppDbContext)));
        });

        services.InitRepositories();
    }
    private static void InitRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserContactRepository, UserContactRepository>();
        services.AddScoped<IServiceLayerRepository, ServiceLayerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPaymentCardRepository, PaymentCardRepository>();
        services.AddScoped<IServiceAuctionRepository, ServiceAuctionRepository>();
        services.AddScoped<IProductAuctionRepository, ProductAuctionRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IPasswordService, PasswordService>();


    }
}