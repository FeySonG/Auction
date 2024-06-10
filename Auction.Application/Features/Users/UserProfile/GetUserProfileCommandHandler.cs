using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Domain.Models.Users;
using Auction.Domain.Result;
using AutoMapper;

namespace Auction.Application.Features.Users.UserProfile
{
    internal class GetUserProfileCommandHandler(IUserRepository repository, IMapper mapper) : ICommandHandler<GetUserProfileCommand, Result<UserGetProfileDTO>>
    {
        public async Task<Result<UserGetProfileDTO>> Handle(GetUserProfileCommand request, CancellationToken cancellationToken)
        {
           var user = await repository.GetUserById(request.UserId);
            if (user == null)
                return new Error(UserErrorCodes.IdNotFound, UserErrorMessages.IdNotFound);

            UserGetProfileDTO profileDTO = new();
            mapper.Map(user, profileDTO);

            return profileDTO;
        }
    }
}
