using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Person
    {

        public int Id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }
        
        public string email { get; set; }

        public string gender { get; set; }

        public string document { get; set; }

        public string type_document { get; set; }

        public string direction { get; set; }

        public string phone { get; set; }

        public DateTime birthday { get; set; }

        public DateTime created_at { get;set; }

        public DateTime created_by { get; set; }

        public DateTime updated_at { get; set;}

        public DateTime updated_by{ get; set; }

        public DateTime deleted_at { get; set; }
        public DateTime deleted_by { get; set; }

        public Boolean state { get; set; }



    }
}
