using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class FloorDto
    {
        public int Id { get; set; }

        public string code { get; set; }
        public int trainingCenterId { get; set; }
    }
}
