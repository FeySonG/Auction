namespace Auction.Application.Features.UserContacts.Update;

internal class UpdateUserContactCommandHandler(
    IUserContactRepository userContactRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : ICommandHandler<UpdateUserContactCommand, Result<UpdateUserContactDTO>>
{
    public async Task<Result<UpdateUserContactDTO>> Handle(UpdateUserContactCommand request, CancellationToken cancellationToken)
    {
        UserContact? usercontact = await userContactRepository.GetByUserIdAsync(request.UserId);

        if (usercontact == null)
            return new Error(ContactErrorCodes.IdNotFound, ContactErrorMessages.NonExistent);

            mapper.Map(request.ContactDTO, usercontact);


        userContactRepository.Update(usercontact);
        await unitOfWork.SaveChangesAsync();

        return request.ContactDTO;
    }

}