using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class EnvironmentsDto
    {

        public int Id { get; set; }
        public string code { get; set; }
        public int floorId { get; set; }
        public int specialtyId { get; set; }
    }
}
