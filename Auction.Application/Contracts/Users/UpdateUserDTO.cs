﻿namespace Auction.Application.Contracts.Users;

public class UpdateUserDTO
{
    public required string NickName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}
