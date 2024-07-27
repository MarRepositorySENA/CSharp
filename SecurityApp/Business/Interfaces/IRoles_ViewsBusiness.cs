using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRoles_ViewsBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Roles_ViewsDto> GetById(int id);
        Task<Roles_Views> Save(Roles_ViewsDto entity);
        Task Update(int id, Roles_ViewsDto entity);
    }
}
