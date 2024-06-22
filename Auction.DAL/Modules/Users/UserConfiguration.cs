namespace Auction.DAL.Modules.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.HasIndex(c => c.Email)
              .IsUnique(true)
              .IsClustered(false);

        builder.HasOne(x => x.BankCard)
            .WithOne()
            .HasForeignKey<PaymentCard>(x => x.UserId);

       

        builder.HasOne(x => x.Contact)
            .WithOne()
            .HasForeignKey<UserContact>(x => x.UserId);
    }
}