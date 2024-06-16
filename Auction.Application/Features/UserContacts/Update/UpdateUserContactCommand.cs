namespace Auction.Application.Features.UserContacts.Update;

public record UpdateUserContactCommand(UpdateUserContactDTO ContactDTO, int UserId): ICommand<Result<UpdateUserContactDTO>>;