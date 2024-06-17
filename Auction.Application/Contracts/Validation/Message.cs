namespace Auction.Application.Contracts.Validation;

public class Message
{
    public const string REQUIRED = "Поле {0} не может быть пустым";
    public const string MAX_LENGTH = "Поле {0} не может быть больше {1}";
    public const string EMAIL = "Поле {0} должно содержать email адресс";
    public const string PHONE = "Поле {0} должно содержать номер телефона";
    public const string ENUM = "Поле {0} должно содержать только существующее значение";
    public const string NON_NEGATIVE = "Поле {0} не может быть отрицательным";
    public const string CANT_BE_PAST = "Поле {0} не может быть прошлым";
    public const string EXPIRY_DATE = "Поле {0} должно содержать дату в формате  MM/YY";
    public const string ONLY_DIGITAL = "Поле {0} должно содержать только цифры";
}