namespace Auction.Application.Features.Users.GetById
{
    internal class GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        : IQueryHandler<GetByIdUserQuery, Result<UserResponseDTO>>
    {
        public async Task<Result<UserResponseDTO>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserById(request.Id);
            if (user == null)
                return new Error(UserErrorCodes.IdNotFound, UserErrorMessages.IdNotFound);

            return mapper.Map<UserResponseDTO>(user);
        }
    }
}
