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

        public bool state { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime createdBy { get; set; }

        public DateTime updatedAt { get; set; }
        public DateTime updatedBy { get; set; }

        public DateTime deletedAt { get; set; }
        public DateTime deletedBy { get; set; }
    }
}
