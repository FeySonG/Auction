namespace Auction.DAL.Modules.Services
{
    public class ServiceLayerConfiguration : IEntityTypeConfiguration<ServiceLayer>
    {
        public void Configure(EntityTypeBuilder<ServiceLayer> builder)
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
