using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string passsword { get; set;  }

        public Person person { get; set; }
        public int PersonId { get; set; }

        public DateTime created_at { get; set; }

        public DateTime created_by { get; set; }

        public DateTime updated_at { get; set; }

        public DateTime updated_by { get; set; }

        public DateTime deleted_at { get; set; }
        public DateTime deleted_by { get; set; }

        public Boolean state { get; set; }


    }
}
