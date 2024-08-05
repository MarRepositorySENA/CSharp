using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRoles_ViewsData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Roles_ViewsDto>> SelectAll();
        Task<Roles_Views> GetById(int id);
        Task<Roles_Views> Save(Roles_Views entity);
        Task Update(Roles_Views entity);
        Task<Roles_Views> GetByCode(string code);
    }
}
