using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUsers_RolesData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Users_RolesDto>> SelectAll();
        Task<Users_Roles> GetById(int id);
        Task<Users_Roles> Save(Users_Roles entity);
        Task Update(Users_Roles entity);
        Task<Users_Roles> GetByCode(string code);
    }
}
