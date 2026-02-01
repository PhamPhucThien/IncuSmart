using IncuSmart.Application.Ports.Inbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncuSmart.Application.Usecases
{
    public class AuthUseCase : IAuthUseCase
    {
        public async Task<string> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
