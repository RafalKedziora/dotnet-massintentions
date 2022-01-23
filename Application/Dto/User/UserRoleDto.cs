using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UserRoleDto
    {
        public string Email { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
