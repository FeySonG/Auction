using Auction.Domain.Models.Users;

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


        if (request.ContactDTO.City == null || request.ContactDTO.City == "string")
            request.ContactDTO.City = usercontact.City;

        if (request.ContactDTO.Country == null || request.ContactDTO.Country == "string")
            request.ContactDTO.Country = usercontact.Country;

        if (request.ContactDTO.Instagram == null || request.ContactDTO.Instagram == "string")
            request.ContactDTO.Instagram = usercontact.Instagram;

        if (request.ContactDTO.Telegram == null || request.ContactDTO.Telegram == "string")
            request.ContactDTO.Telegram = usercontact.Telegram;

        if (request.ContactDTO.PhoneNumber == null || request.ContactDTO.PhoneNumber == "string")
            request.ContactDTO.PhoneNumber = usercontact.PhoneNumber;


        mapper.Map(request.ContactDTO, usercontact);


        userContactRepository.Update(usercontact);
        await unitOfWork.SaveChangesAsync();

        return request.ContactDTO;
    }

}