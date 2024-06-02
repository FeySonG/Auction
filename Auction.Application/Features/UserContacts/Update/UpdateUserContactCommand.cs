using Auction.Application.Abstractions;
using Auction.Application.Contracts.UserContacts;
using Auction.Domain.Models.Result;

namespace Auction.Application.Features.UserContacts.Update
{
    public record UpdateUserContactCommand(UserContactUpdateDTO contactDTO): ICommand<Result>;
    
}
