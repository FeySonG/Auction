﻿
namespace Auction.Application.Features.ProductAuctions
{
    public class ProductAuctionErrorCode
    {
        public const string ProductAuctionIsNotFound = "Auction.IsNotFound";
        public const string OfferWasNotAccepted = "Auction.OfferWasNotAccepted";
        public const string PriceIsLess = "Auction.PriceIsLess";
    }
}
