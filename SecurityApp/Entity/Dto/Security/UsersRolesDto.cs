using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class UsersRolesDto
    {

        public int Id { get; set; }

        public int roleId { get; set; }
        public int userId { get; set; }
        public bool state { get; set; }
    }
}
