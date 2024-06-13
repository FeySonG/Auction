namespace Auction.Application.Features.UserContacts
{

    public class UserContactMapper : Profile
    {
        public UserContactMapper()
        {
            CreateMap<UserContact, UserContactUpdateDTO>().ReverseMap();

            CreateMap<UserContact, UserContactCreateDTO>().ReverseMap();
        }
    }
}