using Auction.Application.Errors.User;

namespace Auction.Application.Features.Users.UserProfile;

internal class GetUserProfileCommandHandler(IUserRepository repository, IMapper mapper) : ICommandHandler<GetUserProfileCommand, Result<GetUserProfileDTO>>
{
    public async Task<Result<GetUserProfileDTO>> Handle(GetUserProfileCommand request, CancellationToken cancellationToken)
    {
       var user = await repository.GetUserById(request.UserId);
        if (user == null)
            return new Error(UserErrorCodes.IdNotFound, UserErrorMessages.IdNotFound);

        GetUserProfileDTO profileDTO = new();
        mapper.Map(user, profileDTO);

        return profileDTO;
    }
}