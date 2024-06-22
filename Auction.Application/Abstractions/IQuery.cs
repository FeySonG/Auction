namespace Auction.Application.Abstractions;

/// <summary>
/// Defines a query that returns a response.
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface IQuery<TResponse> : IRequest<TResponse>;
