namespace Auction.DAL.Modules.PaymentCards;

public class PaymentCardConfiguration : IEntityTypeConfiguration<PaymentCard>
{
    public void Configure(EntityTypeBuilder<PaymentCard> builder)
    {
        builder.HasOne<User>()
              .WithMany()
              .HasForeignKey(x => x.UserId);

        builder.Property(x => x.Balance)
            .HasPrecision(18, 2);
    }
}