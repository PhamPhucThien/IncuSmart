namespace IncuSmart.Core.Ports.Inbound
{
    public interface IAuthUseCase
    {
        Task<string?> Login(LoginCommand command);

        Task<bool> Register(RegisterCommand command);
    }
}
