using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRolesData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();

        Task<IEnumerable<RolesDto>> SelectAll();
        Task<Roles> GetById(int id);
        Task<Roles> Save(Roles entity);
        Task Update(Roles entity);
        Task<Roles> GetByCode(string code);
    }
}
