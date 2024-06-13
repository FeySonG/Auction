namespace Auction.Application.Features.UserContacts.Update
{
    public record UpdateUserContactCommand(UserContactUpdateDTO ContactDTO, int UserId): ICommand<Result<UserContactUpdateDTO>>;
    
}
