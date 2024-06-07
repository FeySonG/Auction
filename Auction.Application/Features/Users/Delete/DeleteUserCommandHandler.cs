using Auction.Application.Abstractions;
using Auction.Application.Services;
using Auction.Domain.Models.Users;
using Auction.Domain.Result;

namespace Auction.Application.Features.Users.Delete
{
    public class DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteUserCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByUserIdAsync(request.id);
            if (user == null)
                return new Error(UserErrorCodes.IdNotFound, UserErrorMessages.IdNotFound);

            userRepository.Remove(user);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

    }

}
