using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interfaces
{
    public interface ICityData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<City>> SelectAll();
        Task<City> GetById(int id);
        Task<City> Save (City entity);
        Task Update (City entity);
        Task<City> GetByAcronym (string acronym);
  
    }
}
