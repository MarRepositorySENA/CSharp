using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interfaces
{
    public interface ICountryData
    {

        Task Delete(int id);
        Task<Country> GetById(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Country>> SelectAll();
        Task<Country> Save(Country entity);
        Task Update (Country entity);
        Task<Country> GetByAcronym(string acronym);



    }
}
