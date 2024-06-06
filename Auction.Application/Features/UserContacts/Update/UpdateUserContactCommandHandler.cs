using Auction.Application.Abstractions;
using Auction.Application.Contracts.UserContacts;
using Auction.Application.Services;
using Auction.Domain.Models.UserContacts;
using Auction.Domain.Result;
using AutoMapper;

namespace Auction.Application.Features.UserContacts.Update;

internal class UpdateUserContactCommandHandler(
    IUserContactRepository userContactRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : ICommandHandler<UpdateUserContactCommand, Result<UserContactUpdateDTO>>
{
    public async Task<Result<UserContactUpdateDTO>> Handle(UpdateUserContactCommand request, CancellationToken cancellationToken)
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
