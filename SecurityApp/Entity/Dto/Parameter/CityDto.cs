using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class CityDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string acronym { get; set; }
        public bool state { get; set; }
    }
}
