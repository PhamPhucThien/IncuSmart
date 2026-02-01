using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncuSmart.Application.Ports.Inbound
{
    public interface IAuthUseCase
    {
        Task<string> Login(string username, string password);
    }
}
