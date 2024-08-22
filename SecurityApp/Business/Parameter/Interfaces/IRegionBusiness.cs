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
    public interface IRegionBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Region>> SelectAll();
        Task<RegionDto> GetById(int id);
        Task<Region> Save(RegionDto entity);
        Task Update(int id, RegionDto entity);
    }
}
