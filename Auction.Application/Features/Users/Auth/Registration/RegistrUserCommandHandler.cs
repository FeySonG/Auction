namespace Auction.Application.Features.Users.Auth.Registration;

internal class RegistrUserCommandHandler(
    IUserRepository userRepository
    , IUnitOfWork unitOfWork
    , IMapper mapper
    ,IPasswordService passwordService) 
    : ICommandHandler<RegistrUserCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(RegistrUserCommand request, CancellationToken cancellationToken)
    {
        var emailCheck = await userRepository.CheckUniqueEmailAsync(request.dto.Email);
        var nickNameCheck = await userRepository.CheckUniqueNickNameAsync(request.dto.NickName);

        if (emailCheck != null)
            return new Error(UserErrorCodes.EmailIsNotUnique, UserErrorMessages.EmailIsNotUnique);

        if (nickNameCheck != null)
            return new Error(UserErrorCodes.NickNameIsNotUnique, UserErrorMessages.NickNameIsNotUnique);

            var user = mapper.Map<User>(request.dto);
            user.Password = passwordService.Hash(request.dto.Password);

            userRepository.Add(user);
            await unitOfWork.SaveChangesAsync();
            return true;
    }
}