using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUsersData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Users> GetById(int id);
        Task<Users> Save(Users entity);
        Task Update(Users entity);
        Task<Users> GetByCode(string code);
    }
}
