using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interfaces
{
    public interface IRegionData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Region>> SelectAll();
        Task<Region> GetById(int id);
        Task<Region> Save(Region entity);
        Task Update(Region entity);
        Task<Region> GetByAcronym(string acronym);
    }
}
