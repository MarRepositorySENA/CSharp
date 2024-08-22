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
    public interface IEnvironmentsBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Environments>> SelectAll();
        Task<EnvironmentsDto> GetById(int id);
        Task<Environments> Save(EnvironmentsDto entity);
        Task Update(int id, EnvironmentsDto entity);
    }
}
