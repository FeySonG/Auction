using Auction.Application.Errors.PaymentCard;

namespace Auction.Application.Features.PaymentCards.Update;

internal class UpdatePaymentCardCommandHandler(
    IPaymentCardRepository repository,
    IUnitOfWork uow,
    IMapper mapper)
    : ICommandHandler<UpdatePaymentCardCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdatePaymentCardCommand request, CancellationToken cancellationToken)
    {
        var card = await repository.GetByUserIdAsync(request.UserId);

        if (card == null)
            return new Error(PaymentCardErrorCodes.UserIdNotFound, PaymentCardErrorMessages.UserIdNotFound);

        mapper.Map(request.PaymentCardDTO, card);

        repository.Update(card);

        await uow.SaveChangesAsync();

        return true;
    }
}