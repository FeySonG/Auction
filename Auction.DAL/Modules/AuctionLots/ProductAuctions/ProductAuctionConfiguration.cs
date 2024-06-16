namespace Auction.DAL.Modules.AuctionLots.ProductAuctions;

public class ProductAuctionConfiguration : IEntityTypeConfiguration<ProductAuction>
{
    public void Configure(EntityTypeBuilder<ProductAuction> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CurrentPrice)
            .HasPrecision(18, 2);

        builder.Property(x => x.StartingPrice)
            .HasPrecision(18, 2);
    }
}