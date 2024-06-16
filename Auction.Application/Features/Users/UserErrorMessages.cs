namespace Auction.Application.Features.Users;

public class UserErrorMessages
{
    public const string NonExistent = "attempt to update a non-existent user.";
    public const string Existent = "attempt to create a existent user.";
    public const string IdNotFound = "attempt to found a non-existent user.";
    public const string EmailIsNotUnique = "attempt to use a existent user Email.";
    public const string NickNameIsNotUnique = "attempt to use a existent user NickName.";
    public const string WrongEmailOrPassword = "Wrong Email or Password";
}