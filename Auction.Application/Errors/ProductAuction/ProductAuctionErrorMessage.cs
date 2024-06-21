namespace Auction.Application.Errors.ProductAuction;

public class ProductAuctionErrorMessage
{
    public const string ProductAuctionIsNotFound = "Auction is not found!";
    public const string OfferWasNotAccepted = "The offer was not accepted, at the time of the auction or did not arrive or the auction has already ended.";
    public const string PriceIsLess = "The offered price is less than the current one!";
    public const string CannotBetOnYourLot = "Cannot bet your Lot";
}