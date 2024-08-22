using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Operational;

namespace Entity.Model.Parameter
{
    public class Environments
    {

        public int Id { get; set; }

        public string code{ get; set; }
        public Floor floor { get; set; }
        public int floorId { get; set; }

        public Specialty specialty { get; set; }
        public int specialtyId {  get; set; }

        //Atributos de auditoria 

        public DateTime createdAt { get; set; } //= DateTime.UtcNow;
        public DateTime createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime updatedBy { get; set; }
        public DateTime? deletedAt { get; set; }
        public DateTime? deletedBy { get; set; }


        public Environments()
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
