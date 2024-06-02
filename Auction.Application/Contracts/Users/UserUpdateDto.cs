namespace Auction.Application.Contracts.Users
{
    public class UserUpdateDto
    {
        public required string NickName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
