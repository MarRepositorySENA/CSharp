using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class Floor
    {
        public int Id { get; set; }

        public string code { get; set; }
        public TrainingCenter trainingCenter { get; set; }
        public int trainingCenterId { get; set; }
        //Atributos de auditoria 

        public DateTime createdAt { get; set; } //= DateTime.UtcNow;
        public DateTime createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime updatedBy { get; set; }
        public DateTime? deletedAt { get; set; }
        public DateTime? deletedBy { get; set; }


        public Floor()
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
