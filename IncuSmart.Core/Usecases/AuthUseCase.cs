namespace IncuSmart.Application.Usecases
{
    public class AuthUseCase : IAuthUseCase
    {
        public readonly IUserRepository _userRepository;

        public AuthUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string?> Login(LoginCommand command)
        {
            User? user = await _userRepository
                        .FindByUserNameAndDeletedAtIsNull(
                            command.Username
                    );

            if (user == null) return null;

            bool isPasswordValid = PasswordUtil.VerifyPassword(command.Password, user.PasswordHash);

            return isPasswordValid ? JwtUtil.GenerateToken(user) : null;
        }

        public async Task<bool> Register(RegisterCommand command)
        {
            User? user = await _userRepository
                        .FindByUserNameAndDeletedAtIsNull(
                            command.Username
                    );

            if (user != null) return false;

            User newUser = new()
            {
                Username = command.Username,
                PasswordHash = PasswordUtil.HashPassword(command.Password),
                FullName = command.FullName,
                Email = command.Email,
                Phone = command.Phone,
                Status = BaseStatus.ACTIVE,
                Role = Role.CUSTOMER,
                CreatedBy = "SYSTEM",
                CreatedAt = DateTime.UtcNow
            };

            return await _userRepository.Save(newUser);
        }
    }
}
