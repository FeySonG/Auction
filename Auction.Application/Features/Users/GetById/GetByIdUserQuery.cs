namespace Auction.Application.Features.Users.GetById;

public record GetByIdUserQuery(long Id) : IQuery<Result<GetUserDTO>>;