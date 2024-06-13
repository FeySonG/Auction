namespace Auction.Application.Contracts.Users
{
    public class UserResponseDTO
    {
        public long Id { get; set; }    
        public required string NickName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
