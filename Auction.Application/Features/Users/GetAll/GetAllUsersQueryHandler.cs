namespace Auction.Application.Features.Users.GetAll;

public class GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper) 
    : IQueryHandler<GetAllUsersQuery, Result<List<GetUserDTO>>>
{
    public async Task<Result<List<GetUserDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync();
        if (users.Count == 0)
            return new Error(UserErrorCodes.NoContent, "");

        return mapper.Map<List<GetUserDTO>>(users);
    }
}