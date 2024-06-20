namespace Auction.Application.Features.Products.Create;

public record CreateProductCommand(CreateProductDTO Dto) : ICommand<Result<GetProductDTO>>;