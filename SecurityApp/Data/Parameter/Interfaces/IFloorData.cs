using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interfaces
{
    public interface IFloorData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Floor >> SelectAll();
        Task<Floor > GetById(int id);
        Task<Floor > Save(Floor  entity);
        Task Update(Floor  entity);
        
    }
}
