using Auction.Application.Abstractions;
using Auction.Application.Contracts.Users;
using Auction.Application.Services;
using Auction.Domain.Models.Users;
using Auction.Domain.Result;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Features.Users.Update
{
    public class UpdateUserCommandHandler(
        IUserRepository repository,
        IMapper mapper,
        IUnitOfWork uow)
        : ICommandHandler<UpdateUserCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await  repository.GetUserById(request.UserID);
            if (user == null)
                return new Error(UserErrorCodes.IdNotFound, UserErrorMessages.IdNotFound);

            var emailCheck = await repository.CheckUniqueEmailAsync(request.UserDTO.Email);
            var nickNameCheck = await repository.CheckUniqueNickNameAsync(request.UserDTO.NickName);

            if (emailCheck != null)
                return new Error(UserErrorCodes.EmailIsNotUnique, UserErrorMessages.EmailIsNotUnique);

            if (nickNameCheck != null)
                return new Error(UserErrorCodes.NickNameIsNotUnique, UserErrorMessages.NickNameIsNotUnique);


            mapper.Map(request.UserDTO, user);

            repository.Update(user);
            await uow.SaveChangesAsync();
            return true;
        }
    }
}
