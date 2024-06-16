namespace Auction.Application.Features.Users.Auth.Registration;

public record RegistrUserCommand(CreateUserDTO dto) : ICommand<Result<bool>>;