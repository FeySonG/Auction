using Auction.Application.Abstractions;
using Auction.Application.Contracts.Services;
using Auction.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.ServiceLayers.GetByName
{
    public record GetByNameServiceLayerQuery(string ServiceName) : IQuery<Result<List<ResponseServiceLayerDto>>>;

}
