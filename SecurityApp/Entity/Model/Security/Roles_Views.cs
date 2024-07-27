using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Roles_Views
    {

        public int Id { get; set; }

        public Roles role { get; set; }
        public int roleId { get; set; }

        public Views view { get; set; }
        public int viewId { get; set; }

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
