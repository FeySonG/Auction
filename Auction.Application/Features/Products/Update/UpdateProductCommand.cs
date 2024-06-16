namespace Auction.Application.Features.Products.Update;

public record UpdateProductCommand(UpdateProductDTO Dto, long Id) : ICommand<Result<GetProductDTO>>;