namespace Auction.Application.Features.UserContacts;


public class UserContactMapper : Profile
{
    public UserContactMapper()
    {
        CreateMap<UserContact, UpdateUserContactDTO>().ReverseMap();

        CreateMap<UserContact, CreateUserContactDTO>().ReverseMap();
    }
}