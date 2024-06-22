namespace Auction.Application.Features.PaymentCards.Delete;

/// <summary>
/// Command handler to delete a payment card.
/// </summary>
internal class DeletePaymentCardCommandHandler : ICommandHandler<DeletePaymentCardCommand, Result<bool>>
{
    private readonly IPaymentCardRepository _repository;
    private readonly IUnitOfWork _uow;

    public DeletePaymentCardCommandHandler(IPaymentCardRepository repository, IUnitOfWork uow)
    {
        _repository = repository;
        _uow = uow;
    }

    /// <summary>
    /// Handles the deletion of a payment card based on the user ID.
    /// </summary>
    /// <param name="request">The command request containing the user ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Result{Boolean}"/> indicating the success of the operation.</returns>
    public async Task<Result<bool>> Handle(DeletePaymentCardCommand request, CancellationToken cancellationToken)
    {
        var card = await _repository.GetByUserIdAsync(request.UserId);
        if (card == null)
            return new Error(PaymentCardErrorCodes.IsNotExist, PaymentCardErrorMessages.IsNotExistToDelete);

        _repository.Remove(card);
        await _uow.SaveChangesAsync();

        return true;
    }
}
