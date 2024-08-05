using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IRoles_ViewsBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Roles_ViewsDto>> SelectAll();
        Task<Roles_ViewsDto> GetById(int id);
        Task<Roles_Views> Save(Roles_ViewsDto entity);
        Task Update(int id, Roles_ViewsDto entity);
    }
}
