using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUsers_RolesBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Users_RolesDto> GetById(int id);
        Task<Users_Roles> Save(Users_RolesDto entity);
        Task Update(int id, Users_RolesDto entity);
    }
}
