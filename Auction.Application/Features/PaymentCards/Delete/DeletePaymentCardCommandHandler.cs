namespace Auction.Application.Features.PaymentCards.Delete;

internal class DeletePaymentCardCommandHandler 
    (IPaymentCardRepository repository,
    IUnitOfWork uow)
    : ICommandHandler<DeletePaymentCardCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeletePaymentCardCommand request, CancellationToken cancellationToken)
    {
        var card = await repository.GetByUserIdAsync(request.UserId);
        if (card == null)
            return new Error(PaymentCardErrorCodes.IsNotExist,PaymentCardErrorMessages.IsNotExistToDelete);

        repository.Remove(card);
        await uow.SaveChangesAsync();

        return true;
    }
}