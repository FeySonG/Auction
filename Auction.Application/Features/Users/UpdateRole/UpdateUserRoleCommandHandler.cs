﻿namespace Auction.Application.Features.Users.UpdateRole;

internal class UpdateUserRoleCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserRoleCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUserIdAsync(request.userId);

        if (user == null)
            return new Error(UserErrorCodes.IdNotFound, UserErrorMessages.IdNotFound);

        user.Role = request.role;

        userRepository.Update(user);
        await unitOfWork.SaveChangesAsync();

        return true;
    }
}