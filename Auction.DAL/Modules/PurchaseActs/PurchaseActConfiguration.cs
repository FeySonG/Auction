namespace Auction.DAL.Modules.PurchaseActs;

public class PurchaseActConfiguration : IEntityTypeConfiguration<PurchaseAct>
{
    public void Configure(EntityTypeBuilder<PurchaseAct> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Price)
            .HasPrecision(18, 2);
    }
}