using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IUsersBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsersDto>> SelectAll();
        Task<UsersDto> GetById(int id);
        Task<Users> Save(UsersDto entity);
        Task Update(int id, UsersDto entity);
    }
}
