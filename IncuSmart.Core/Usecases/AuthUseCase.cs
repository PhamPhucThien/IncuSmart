namespace IncuSmart.Core.Usecases
{
    public class AuthUseCase : IAuthUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public AuthUseCase(IUserRepository userRepository, ICustomerRepository customerRepository, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _uow = uow;
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

            await _uow.BeginAsync();
            try
            {
                Guid userId = Guid.NewGuid();

                User newUser = new()
                {
                    Id = userId,
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

                await _userRepository.Add(newUser);
                await _uow.SaveChangesAsync();

                Customer newCustomer = new()
                {
                    Status = BaseStatus.ACTIVE,
                    UserId = userId,
                    CreatedBy = "SYSTEM",
                    CreatedAt = DateTime.UtcNow
                };

                await _customerRepository.Add(newCustomer);
                await _uow.SaveChangesAsync();
                await _uow.CommitAsync();
                return true;
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }
    }
}
