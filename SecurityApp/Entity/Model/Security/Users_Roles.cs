using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Users_Roles
    {
        public int Id { get; set; }

        public Roles role { get; set; }
        public int roleId { get; set; } 
        public Users user { get; set; }
        public int userId { get; set; }


        public bool state { get; set; }
        public string code { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime createdBy { get; set; }

        public DateTime updatedAt { get; set; }
        public DateTime updatedBy { get; set; }

        public DateTime deletedAt { get; set; }
        public DateTime deletedBy { get; set; }
    }
}
