using Entity.Dto.Parameter;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interfaces
{
    public interface IEnvironmentsData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Environments>> SelectAll();
        Task<Environments> GetById(int id);
        Task<Environments> Save(Environments entity);
        Task Update(Environments entity);
        
    }
}
