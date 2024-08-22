using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class TrainingCenterDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string acronym { get; set; }
        public string address { get; set; }
        public bool state { get; set; }

        public int cityId { get; set; }
        public int regionId { get; set; }
    }
}
