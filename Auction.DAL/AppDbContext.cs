using System.Reflection;

namespace Auction.DAL
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<UserContact> UserContacts => Set<UserContact>();
        public DbSet<PaymentCard> PaymentCards => Set<PaymentCard>();
        public DbSet<PurchaseAct> PurchaseActs => Set<PurchaseAct>();
        public DbSet<ServiceLayer> Services => Set<ServiceLayer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductAuction> ProductAuctions => Set<ProductAuction>();
        public DbSet<ServiceAuction> ServiceAuctions => Set<ServiceAuction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
