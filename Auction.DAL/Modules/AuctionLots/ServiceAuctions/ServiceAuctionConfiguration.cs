namespace Auction.DAL.Modules.AuctionLots.ServiceAuctions;

public class ServiceAuctionConfiguration : IEntityTypeConfiguration<ServiceAuction>
{
    public void Configure(EntityTypeBuilder<ServiceAuction> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CurrentPrice)
            .HasPrecision(18, 2);

        builder.Property(x => x.StartingPrice)
            .HasPrecision(18, 2);
    }
}