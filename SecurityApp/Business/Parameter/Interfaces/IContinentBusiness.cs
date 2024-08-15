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
    public interface IContinentBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Continent>> SelectAll();
        Task<ContinentDto> GetById(int id);
        Task<Continent> Save(ContinentDto entity);
        Task Update(int id, ContinentDto entity);
    }
}
