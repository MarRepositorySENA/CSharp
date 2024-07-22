using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class User_Role
    {
        public int Id { get; set; }

        public Role role { get; set; }
        public int IdRole { get; set; } 
        public User user { get; set; }
        public int IdUser { get; set; }


        public bool state { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime createdBy { get; set; }

        public DateTime updatedAt { get; set; }
        public DateTime updatedBy { get; set; }

        public DateTime deletedAt { get; set; }
        public DateTime deletedBy { get; set; }
    }
}
