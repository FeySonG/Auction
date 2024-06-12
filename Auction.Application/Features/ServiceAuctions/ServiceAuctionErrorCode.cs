using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.ServiceAuctions
{
    public class ServiceAuctionErrorCode
    {
        public const string ServiceAuctionIsNotFound = "Auction.IsNotFound";
        public const string OfferWasNotAccepted = "Auction.OfferWasNotAccepted";
        public const string PriceIsLess = "Auction.PriceIsLess";
    }
}
