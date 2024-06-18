namespace Auction.Application.Features.PaymentCards.Create;

internal class CreatePaymentCardCommandHandler(IPaymentCardRepository repository, IUnitOfWork uow, IMapper mapper)
    : ICommandHandler<CreatePaymentCardCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreatePaymentCardCommand request, CancellationToken cancellationToken)
    {
        if (repository.CheckExistToCreate(request.UserId))
            return new Error(PaymentCardErrorCodes.AlreadyExist,PaymentCardErrorMessages.AlreadyExistToCreate);
        
        PaymentCard card = mapper.Map<PaymentCard>(request.CardDTO);

        card.UserId = request.UserId;

        repository.Add(card);
        await uow.SaveChangesAsync();

        return true;
    }
}