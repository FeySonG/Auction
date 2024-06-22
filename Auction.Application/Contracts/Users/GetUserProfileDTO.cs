namespace Auction.Application.Contracts.Users;

/// <summary>
/// DTO for getting user profile information.
/// </summary>
public class GetUserProfileDTO
{
    /// <summary>
    /// Gets or sets the nickname of the user.
    /// </summary>
    public string? NickName { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the contact information of the user.
    /// </summary>
    public GetUserContactDTO? Contact { get; set; }

    /// <summary>
    /// Gets or sets the bank card information of the user.
    /// </summary>
    public GetPaymentCardDTO? BankCard { get; set; }
}
