namespace Auction.Application.Features.PaymentCards.Create;

internal class CreatePaymentCardCommandHandler(IPaymentCardRepository repository, IUnitOfWork uow)
    : ICommandHandler<CreatePaymentCardCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreatePaymentCardCommand request, CancellationToken cancellationToken)
    {
        if (repository.CheckExistToCreate(request.UserId))
            return new Error(PaymentCardErrorCodes.AlreadyExist,PaymentCardErrorMessages.AlreadyExistToCreate);
        
        PaymentCard card = request.CardDTO.Adapt<PaymentCard>();
        card.UserId = request.UserId;

        repository.Add(card);
        await uow.SaveChangesAsync();

        return true;

    }
}