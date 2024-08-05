using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IViewsData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ViewsDto>> SelectAll();
        Task<Views> GetById(int id);
        Task<Views> Save(Views entity);
        Task Update(Views entity);
        Task<Views> GetByCode(string code);
    }
}
