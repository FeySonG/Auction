namespace Auction.Application.Features.Users.Auth.Registration
{
    public class RegistrUserCommandHandler(
        IUserRepository userRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper
        ,IPasswordService passwordService) 
        : ICommandHandler<RegistrUserCommand, bool>
    {
        public async Task<bool> Handle(RegistrUserCommand request, CancellationToken cancellationToken)
        {
            var emailCheck = await userRepository.CheckUniqueEmailAsync(request.dto.Email);
            var nickNameCheck = await userRepository.CheckUniqueNickNameAsync(request.dto.NickName);
            if(emailCheck == null && nickNameCheck == null)
            {
                var user = mapper.Map<User>(request.dto);

                user.Password = passwordService.Hash(request.dto.Password);

                userRepository.Add(user);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
