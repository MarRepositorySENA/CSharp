using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Users
    {
        public int Id { get; set; }

        public string username { get; set; }

        public string passsword { get; set;  }

        public Persons person { get; set; }
        public int personId { get; set; }

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
