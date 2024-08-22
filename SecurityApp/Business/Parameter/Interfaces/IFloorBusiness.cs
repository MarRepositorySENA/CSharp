using Entity.Dto.Parameter;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Interfaces
{
    internal interface IFloorBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Floor>> SelectAll();
        Task<FloorDto> GetById(int id);
        Task<Floor> Save(FloorDto entity);
        Task Update(int id, FloorDto entity);
    }
}
