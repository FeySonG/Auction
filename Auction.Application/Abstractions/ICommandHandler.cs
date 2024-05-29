using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Abstractions
{
    public interface ICommandHandler<TCommand>
    : IRequestHandler<TCommand>
    where TCommand : ICommand;

    public interface ICommandHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>;
}
