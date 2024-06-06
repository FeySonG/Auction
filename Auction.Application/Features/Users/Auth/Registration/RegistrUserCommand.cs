using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Users.Auth.Registration
{
    public record RegistrUserCommand(UserCreateDTO dto) : ICommand<bool>;

}
