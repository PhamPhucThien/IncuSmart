using IncuSmart.Application.Commands;
using IncuSmart.Core.Commands;

namespace IncuSmart.Application.Ports.Inbound
{
    public interface IAuthUseCase
    {
        Task<string?> Login(LoginCommand command);

        Task<bool> Register(RegisterCommand command);
    }
}
