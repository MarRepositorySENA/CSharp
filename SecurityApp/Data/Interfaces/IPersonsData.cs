using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPersonsData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Persons> GetById(int id);
        Task<Persons> Save(Persons entity);
        Task Update(Persons entity);
        Task<Persons> GetByCode(string code);
    }
}
