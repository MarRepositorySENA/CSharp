using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interfaces
{
    public interface IContinentData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Continent>> SelectAll();
        Task<Continent> GetById(int id);
        Task<Continent> Save(Continent entity);
        Task Update(Continent entity);
        Task<Continent> GetByAcronym(string acronym);
    }
}
