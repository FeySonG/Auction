using Auction.Application.Errors.User;

namespace Auction.Application.Features.Users.Auth.Login;

internal class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, Result<User>>
{
    private readonly HttpContext _httpContext;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    public LoginUserQueryHandler(IHttpContextAccessor accessor
        , IUserRepository userRepository
        ,IPasswordService passwordService)
    {

        if (accessor.HttpContext is null)
        {
            throw new ArgumentException(nameof(accessor.HttpContext));
        }
        _passwordService = passwordService;
        _userRepository = userRepository;
        _httpContext = accessor.HttpContext;
    }

    public async Task<Result<User>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.email);

        if (user == null || _passwordService.Verify(request.password, user.Password) == false)
            return new Error(UserErrorCodes.WrongEmailOrPassword, UserErrorMessages.WrongEmailOrPassword);

        await LoginHttpContext(user);
        return user;
    }

    private Task LoginHttpContext(User user)
    {

        var claims = new Claim[]
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString() ),
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.Role, user.Role.ToString()),
            new (ClaimTypes.Expiration, DateTime.UtcNow.AddHours(5).ToString()),
        };
        var identity = new ClaimsIdentity(claims, "Coockies");
        var principal = new ClaimsPrincipal(identity);

        return _httpContext.SignInAsync(principal);
    }
}