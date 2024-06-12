namespace Auction.Application.Features.Users.Auth.Login
{
    public class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, User?>
    {
        private readonly HttpContext _httpContext;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public LoginUserQueryHandler(IHttpContextAccessor accessor
            , IUserRepository userRepository
            , IMapper mapper
            ,IPasswordService passwordService)
        {

            if (accessor.HttpContext is null)
            {
                throw new ArgumentException(nameof(accessor.HttpContext));
            }
            _passwordService = passwordService;
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContext = accessor.HttpContext;
        }
        public async Task<User?> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.email);
            if (user == null) return null;
            if (_passwordService.Verify(request.password, user.Password) == false) return null;

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
}
