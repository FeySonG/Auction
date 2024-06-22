namespace Auction.Application.Abstractions;

/// <summary>
/// Defines a handler for a command that does not return a response.
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand;

/// <summary>
/// Defines a handler for a command that returns a response.
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>;
