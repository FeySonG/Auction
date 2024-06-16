namespace Auction.Application.Features.ServiceAuctions;

public class ServiceAuctionErrorMessage
{
    public const string ServiceAuctionIsNotFound = "Auction is not found!";
    public const string OfferWasNotAccepted = "The offer was not accepted, at the time of the auction or did not arrive or the auction has already ended.";
    public const string PriceIsLess = "The offered price is less than the current one!";
}