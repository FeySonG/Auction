﻿using Auction.Application.Abstractions;
using Auction.Application.Services;
using Auction.Domain.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Users.Delete
{
    public class DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.id);
            if (user == null) return false;
            userRepository.Remove(user);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

    }

}
