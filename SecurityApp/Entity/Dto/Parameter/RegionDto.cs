using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class RegionDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string acronym { get; set; }
        public bool state { get; set; }
        public int departamentId { get; set; }

    }
}
