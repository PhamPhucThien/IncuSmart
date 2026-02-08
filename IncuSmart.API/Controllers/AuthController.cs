namespace IncuSmart.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IAuthUseCase _authUseCase) : ApiControllerBase
    {
        private static readonly AuthMapper _authMapper = new();

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            string? result = await _authUseCase.Login(_authMapper.RequestToLoginCommand(request));

            BaseResponse<LoginResponse> response = new();

            if (result == null)
            {
                response.Data.JwtToken = null;
                response.Message = "Invalid username or password";
                response.StatusCode = API.StatusCode.NOT_FOUND;
            }
            else
            {
                LoginResponse data = new()
                {
                    JwtToken = result
                };

                response.Data = data;
            }


            return FromResult(response);
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            bool result = await _authUseCase.Register(_authMapper.RequestToRegisterCommand(request));

            BaseResponse<string> response = new();

            if (!result) response = new()
            {
                StatusCode = API.StatusCode.CONFLICT,
                Message = "Username already exists",
                Data = ""
            };

            return FromResult(response);
        }
    }
}
