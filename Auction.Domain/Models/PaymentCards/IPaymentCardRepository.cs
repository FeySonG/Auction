namespace Auction.Domain.Models.PaymentCards;

public interface IPaymentCardRepository : IRepository<PaymentCard>
{
    bool CheckExistToCreate(int userId);
}