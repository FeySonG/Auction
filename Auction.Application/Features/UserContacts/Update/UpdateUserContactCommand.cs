using Auction.Application.Abstractions;
using Auction.Application.Contracts.UserContacts;
using Auction.Domain.Result;

namespace Auction.Application.Features.UserContacts.Update
{
    public record UpdateUserContactCommand(UserContactUpdateDTO ContactDTO): ICommand<Result<UserContactUpdateDTO>>;
    
}
