using Auction.Application.Abstractions;
using Auction.Application.Contracts.UserContacts;
using Auction.Domain.Result;

namespace Auction.Application.Features.UserContacts.Create
{
    public record CreateUserContactCommand(UserContactCreateDTO ContactDTO, int UserId) : ICommand<Result<bool>>;
}
