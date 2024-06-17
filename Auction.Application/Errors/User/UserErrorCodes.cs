namespace Auction.Application.Errors.User;

public class UserErrorCodes
{
    public const string IdNotFound = "User.IdNotFound";
    public const string AlreadyExist = "User.AlreadyExist";
    public const string NoContent = "User.NoContent";
    public const string EmailIsNotUnique = "User.EmailIsNotUnique";
    public const string NickNameIsNotUnique = "User.NickNameIsNotUnique";
    public const string WrongEmailOrPassword = "User.EmailOrPasswordIsWrong";
}