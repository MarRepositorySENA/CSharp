using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class TrainingCenter
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string acronym { get; set; }
        public string address { get; set; }
        public bool state { get; set; }

        public City city { get; set; }
        public int cityId {  get; set; }

        public Region region { get; set; }
        public int regionId { get; set; }

        //Atributos de auditoria 

        public DateTime createdAt { get; set; } //= DateTime.UtcNow;
        public DateTime createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime updatedBy { get; set; }
        public DateTime? deletedAt { get; set; }
        public DateTime? deletedBy { get; set; }


        public TrainingCenter()
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
