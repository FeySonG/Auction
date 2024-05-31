using Auction.Application.Services;
using Auction.DAL.Modules.AuctionLots.ProductAuctions;
using Auction.DAL.Modules.AuctionLots.ServiceAuctions;
using Auction.DAL.Modules.PaymentCards;
using Auction.DAL.Modules.Products;
using Auction.DAL.Modules.PurchaseActs;
using Auction.DAL.Modules.Services;
using Auction.DAL.Modules.UserContacts;
using Auction.DAL.Modules.Users;
using Auction.DAL.Services;
using Auction.Domain.Enums.UserEnums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Extensions
{
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
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IPurchaseActRepository, PurchaseActRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPaymentCardRepository, PaymentCardRepository>();
            services.AddScoped<IServiceAuctionRepository, ServiceAuctionRepository>();
            services.AddScoped<IProductAuctionRepository, ProductAuctionRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPasswordService, PasswordService>();


        }
    }
}
