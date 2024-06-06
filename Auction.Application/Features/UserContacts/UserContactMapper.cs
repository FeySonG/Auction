using Auction.Application.Contracts.UserContacts;
using Auction.Application.Contracts.Users;
using Auction.Domain.Models.UserContacts;
using AutoMapper;

namespace Auction.Application.Features.UserContacts
{

    public class UserContactMapper : Profile
    {
        public UserContactMapper()
        {
            CreateMap<UserContact, UserContactUpdateDTO>().ReverseMap();/*.ForMember(dest => dest.UserId, opt => opt.Ignore()); */

            CreateMap<UserContact, UserContactCreateDTO>().ReverseMap();
        }
    }
}