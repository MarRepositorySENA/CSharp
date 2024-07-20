using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class View
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string route{ get; set; }
        public int idModule { get; set; }
        public Module module { get; set; }  
        public DateTime created_at { get; set; }
        public DateTime created_by { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime updated_by { get; set; }
        public DateTime deleted_at { get; set; }
        public DateTime deleted_by { get; set; }
        public Boolean state { get; set; } 
    }
}
