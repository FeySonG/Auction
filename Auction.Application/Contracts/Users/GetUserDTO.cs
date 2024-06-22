namespace Auction.Application.Contracts.Users;

/// <summary>
/// DTO for getting user information.
/// </summary>
public class GetUserDTO
{
    /// <summary>
    /// Gets or sets the ID of the user.
    /// </summary>
    public long Id { get; set; }

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
    /// Gets or sets the role of the user.
    /// </summary>
    public UserRole Role { get; set; }
}
