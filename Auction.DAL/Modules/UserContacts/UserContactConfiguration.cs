namespace Auction.DAL.Modules.UserContacts
{
    public class UserContactConfiguration : IEntityTypeConfiguration<UserContact>
    {
        public void Configure(EntityTypeBuilder<UserContact> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(c => c.Email)
                  .IsUnique(true)
                  .IsClustered(false);
        }
    }
}
