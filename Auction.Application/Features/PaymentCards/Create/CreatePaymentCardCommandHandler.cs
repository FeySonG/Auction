using Auction.Application.Abstractions;
using Auction.Application.Services;
using Auction.Domain.Models.PaymentCards;
using Auction.Domain.Result;
using Mapster;

namespace Auction.Application.Features.PaymentCards.Create
{
    public class CreatePaymentCardCommandHandler(IPaymentCardRepository repository, IUnitOfWork uow)
        : ICommandHandler<CreatePaymentCardCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(CreatePaymentCardCommand request, CancellationToken cancellationToken)
        {
            if (repository.CheckExistToCreate(request.UserId))
                return new Error(PaymentCardErrorCodes.AlreadyExist,PaymentCardErrorMessages.Existent);
            
            PaymentCard card = request.CardDTO.Adapt<PaymentCard>();
            card.UserId = request.UserId;

            repository.Add(card);
            await uow.SaveChangesAsync();

            return true;

        }
    }
}
