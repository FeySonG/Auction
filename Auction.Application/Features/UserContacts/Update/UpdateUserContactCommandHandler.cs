using Auction.Application.Abstractions;
using Auction.Application.Contracts.UserContacts;
using Auction.Application.Services;
using Auction.Domain.Models.UserContacts;
using Auction.Domain.Result;
using Mapster;

namespace Auction.Application.Features.UserContacts.Update;

internal class UpdateUserContactCommandHandler(
    IUserContactRepository userContactRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateUserContactCommand, Result<UserContactUpdateDTO>>
{
    public async Task<Result<UserContactUpdateDTO>> Handle(UpdateUserContactCommand request, CancellationToken cancellationToken)
    {
        UserContact? Usercontact = await userContactRepository.GetByUserIdAsync(request.UserId);

        if (Usercontact == null)
            return new Error(ContactErrorCodes.IdNotFound, ContactErrorMessages.NonExistent);

        //Usercontact = request.ContactDTO.Adapt<UserContact>();

        Usercontact.Country = request.ContactDTO.Country;
        Usercontact.City = request.ContactDTO.City;
        Usercontact.PhoneNumber = request.ContactDTO.PhoneNumber;      // ne rabotaet mapping
        Usercontact.Telegram = request.ContactDTO.Telegram;
        Usercontact.Instagram = request.ContactDTO.Instagram;


        userContactRepository.Update(Usercontact);

        await unitOfWork.SaveChangesAsync();

        return request.ContactDTO;
    }

}
