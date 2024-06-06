using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Users.GetById
{
    public record GetByIdUserQuery(long Id) : IQuery<Result<UserResponseDTO>>;

}
