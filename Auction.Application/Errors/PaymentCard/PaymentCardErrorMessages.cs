namespace Auction.Application.Errors.PaymentCard;

public class PaymentCardErrorMessages
{
    public const string IsNotExistToUpdate = "attempt to update a non-existent payment card.";
    public const string AlreadyExistToCreate = "attempt to create a existent payment card.";
    public const string UserIdNotFound = "attempt to update a non-existent user id payment card .";
    public const string IsNotExistToDelete = "attempt to delete a non-existent payment card.";
}