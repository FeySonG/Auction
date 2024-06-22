namespace Auction.Application.Features.PaymentCards.Create;

/// <summary>
/// Command handler for creating a payment card.
/// </summary>
internal class CreatePaymentCardCommandHandler : ICommandHandler<CreatePaymentCardCommand, Result<bool>>
{
    private readonly IPaymentCardRepository _repository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreatePaymentCardCommandHandler"/> class.
    /// </summary>
    /// <param name="repository">The payment card repository.</param>
    /// <param name="uow">The unit of work.</param>
    /// <param name="mapper">The mapper.</param>
    public CreatePaymentCardCommandHandler(IPaymentCardRepository repository, IUnitOfWork uow, IMapper mapper)
    {
        _repository = repository;
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the creation of a payment card based on the command.
    /// </summary>
    /// <param name="request">The command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A result indicating the success or failure of the operation.</returns>
    public async Task<Result<bool>> Handle(CreatePaymentCardCommand request, CancellationToken cancellationToken)
    {
        // Check if a payment card already exists for the user
        if (_repository.CheckExistToCreate(request.UserId))
        {
            return new Error(PaymentCardErrorCodes.AlreadyExist, PaymentCardErrorMessages.AlreadyExistToCreate);
        }

        // Map DTO to PaymentCard entity
        PaymentCard card = _mapper.Map<PaymentCard>(request.CardDTO);

        card.UserId = request.UserId;

        // Add card to repository and save changes
        _repository.Add(card);
        await _uow.SaveChangesAsync();

        return true;
    }
}
