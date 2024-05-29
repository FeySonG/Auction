using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Abstractions
{
    public interface ICommand<TResponse> : IRequest<TResponse>;

    public interface ICommand : IRequest;
}
