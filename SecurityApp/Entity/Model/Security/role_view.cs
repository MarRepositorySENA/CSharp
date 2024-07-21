using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Role_View
    {

        public int Id { get; set; }

        public Role role { get; set; }
        public int IdRole { get; set; }

        public View view { get; set; }
        public int IdView { get; set; }

        public DateTime created_at { get; set; }

        public DateTime created_by { get; set; }

        public DateTime updated_at { get; set; }

        public DateTime updated_by { get; set; }

        public DateTime deleted_at { get; set; }
        public DateTime deleted_by { get; set; }

        public Boolean state { get; set; }
    }
}
