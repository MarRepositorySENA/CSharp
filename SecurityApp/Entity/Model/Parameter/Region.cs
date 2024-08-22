using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class Region
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string acronym { get; set; }
        public bool state { get; set; }
        public Department departament { get; set; }
        public  int departamentId {  get; set; }


        //Atributos de auditoria 

        public DateTime createdAt { get; set; } //= DateTime.UtcNow;
        public DateTime createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime updatedBy { get; set; }
        public DateTime? deletedAt { get; set; }
        public DateTime? deletedBy { get; set; }


        public Region()
        {
            createdAt = DateTime.UtcNow;
            createdBy = DateTime.UtcNow;
            updatedAt = DateTime.UtcNow;
            updatedBy = DateTime.UtcNow;
            deletedBy = null;
            deletedBy = null;

        }
    }
}
