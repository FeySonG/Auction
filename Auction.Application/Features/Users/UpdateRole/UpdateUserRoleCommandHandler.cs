using Auction.Application.Abstractions;
using Auction.Application.Services;
using Auction.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Users.UpdateRole
{
    public class UpdateUserRoleCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserRoleCommand, bool>
    {
        public async Task<bool> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByUserIdAsync(request.userId);
            if (user == null) return false;

            user.Role = request.role;
            userRepository.Update(user);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
