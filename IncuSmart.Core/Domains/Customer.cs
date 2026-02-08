using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncuSmart.Core.Domains
{
    public class Customer : BaseDomain<BaseStatus>
    {
        public long UserId { get; set; }

        public string? DeviceToken { get; set; }

        public string? PinNumberHash { get; set; }

        public string? Address { get; set; }
    }
}
