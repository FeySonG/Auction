namespace Auction.DAL.Modules.Services
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne<User>()
              .WithMany()
              .HasForeignKey(x => x.UserId);

            builder.Property(x => x.Price)
                .HasPrecision(18, 2);
        }
    }
}
