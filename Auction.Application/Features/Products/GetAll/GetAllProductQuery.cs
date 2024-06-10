using Auction.Application.Abstractions;
using Auction.Application.Contracts.Products;
using Auction.Domain.Result;

namespace Auction.Application.Features.Products.GetAll
{
    public class GetAllProductQuery : IQuery<Result<List<ResponseProductDto>>>;
}
