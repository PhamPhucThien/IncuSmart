using IncuSmart.Infra.Persistences.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncuSmart.Infra.Persistences.Entity
{
    [Table("users")]
    public class UserEntity : BaseEntity<BaseStatus>
    {
        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }

        public string? Phone { get; set; }
    }

}
