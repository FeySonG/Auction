namespace Auction.Application.Contracts.UserContacts;

/// <summary>
/// DTO for retrieving user contact information.
/// </summary>
public class GetUserContactDTO
{
    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Telegram handle of the user.
    /// </summary>
    public string Telegram { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Instagram handle of the user.
    /// </summary>
    public string Instagram { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the city where the user resides.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the country where the user resides.
    /// </summary>
    public string Country { get; set; } = string.Empty;
}
