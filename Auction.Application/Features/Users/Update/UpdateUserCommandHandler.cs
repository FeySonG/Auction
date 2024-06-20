namespace Auction.Application.Features.Users.Update;

internal class UpdateUserCommandHandler(IUserRepository repository, IMapper mapper, IUnitOfWork uow)
    : ICommandHandler<UpdateUserCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetUserById(request.UserID);
        if (user == null)
            return new Error(UserErrorCodes.IdNotFound, UserErrorMessages.IdNotFound);


        var emailCheck = await repository.CheckUniqueEmailAsync(request.UserDTO.Email!);

        var nickNameCheck = await repository.CheckUniqueNickNameAsync(request.UserDTO.NickName!);

        if (emailCheck != null)
            return new Error(UserErrorCodes.EmailIsNotUnique, UserErrorMessages.EmailIsNotUnique);

        if (nickNameCheck != null)
            return new Error(UserErrorCodes.NickNameIsNotUnique, UserErrorMessages.NickNameIsNotUnique);


        if (request.UserDTO.FirstName == null || request.UserDTO.FirstName == "string")
            request.UserDTO.FirstName = user.FirstName;

        if (request.UserDTO.LastName == null || request.UserDTO.LastName == "string")
            request.UserDTO.LastName = user.LastName;

        if (request.UserDTO.Email == null || request.UserDTO.Email == "user@example.com")
            request.UserDTO.Email = user.Email;

        if (request.UserDTO.NickName == null || request.UserDTO.NickName == "string")
            request.UserDTO.NickName = user.NickName;


        mapper.Map(request.UserDTO, user);

        repository.Update(user);
        await uow.SaveChangesAsync();
        return true;
    }
}
