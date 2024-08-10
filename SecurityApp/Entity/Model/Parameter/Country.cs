using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class Country
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string acronym { get; set; }

        public  bool state { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime createdBy { get; set; }

        public DateTime updatedAt { get; set; }
        public DateTime updatedBy { get; set; }

        public DateTime? deletedAt { get; set; } // Nullable DateTime
        public DateTime? deletedBy { get; set; } // Nullable DateTime


        public Country()
        {
            createdAt = DateTime.UtcNow;
            createdBy = DateTime.UtcNow; // Puede ser cambiado según la lógica de tu aplicación
            updatedAt = DateTime.UtcNow;
            updatedBy = DateTime.UtcNow; // Puede ser cambiado según la lógica de tu aplicación
            deletedAt = null;
            deletedBy = null; // No establezcas valores predeterminados para deletedAt y deletedBy
        }
    }
}
