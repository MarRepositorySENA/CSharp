using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class LoginDto
    {
        public string? UserName { get; set; }
        public string? password { get; set; }
        public int Id { get; }
        public int RoleId { get; }
    }
}
