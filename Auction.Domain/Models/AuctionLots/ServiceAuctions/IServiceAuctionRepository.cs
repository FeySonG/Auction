using Auction.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models.AuctionLots.ServiceAuctions
{
    public interface IServiceAuctionRepository : IRepository<ServiceAuction>
    {
    }
}
