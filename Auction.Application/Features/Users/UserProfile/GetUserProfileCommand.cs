using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Users.UserProfile
{
    public record GetUserProfileCommand(int UserId) : ICommand<Result<UserGetProfileDTO>>;
}
