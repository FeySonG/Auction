namespace Auction.DAL.Modules.PaymentCards
{
    public class PaymentCardRepository(AppDbContext dbContext) : IPaymentCardRepository
    {
        public void Add(PaymentCard card) => dbContext.Add(card);

        public bool CheckExistToCreate(int userId)
        {
            if (dbContext.PaymentCards.Any(c => c.UserId == userId))
                return true;
            return false;
        }

        public async Task<List<PaymentCard>> GetAllAsync() => await dbContext.PaymentCards.ToListAsync();

        public async Task<PaymentCard?> GetByUserIdAsync(long userId) => await dbContext.PaymentCards.FirstOrDefaultAsync(c => c.UserId == userId);

        public void Remove(PaymentCard card) => dbContext.PaymentCards.Remove(card);

        public void Update(PaymentCard card) => dbContext.PaymentCards.Update(card);
    }
}
