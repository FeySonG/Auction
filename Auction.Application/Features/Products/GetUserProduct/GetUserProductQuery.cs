using Auction.Application.Abstractions;
using Auction.Application.Contracts.Products;
using Auction.Domain.Result;

namespace Auction.Application.Features.Products.GetUserProduct
{
    public class GetUserProductQuery : IQuery<Result<List<ResponseProductDto>>>;

}
