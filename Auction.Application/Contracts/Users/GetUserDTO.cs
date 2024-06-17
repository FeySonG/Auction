﻿namespace Auction.Application.Contracts.Users;

public class GetUserDTO
{
    public long Id { get; set; }    
    public string NickName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}