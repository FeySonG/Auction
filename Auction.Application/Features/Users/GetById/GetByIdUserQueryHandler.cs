namespace Auction.Application.Features.Users.GetById;

internal class GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    : IQueryHandler<GetByIdUserQuery, Result<GetUserDTO>>
{
    public async Task<Result<GetUserDTO>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.Id);
        if (user == null)
            return new Error(UserErrorCodes.IdNotFound, UserErrorMessages.IdNotFound);

        return mapper.Map<GetUserDTO>(user);
    }
}