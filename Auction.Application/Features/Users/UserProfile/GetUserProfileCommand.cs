namespace Auction.Application.Features.Users.UserProfile;

public record GetUserProfileCommand(int UserId) : ICommand<Result<GetUserProfileDTO>>;