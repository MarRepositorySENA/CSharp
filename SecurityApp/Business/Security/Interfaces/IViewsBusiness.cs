using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interfaces
{
    public interface IViewsBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ViewsDto>> SelectAll();
        Task<ViewsDto> GetById(int id);
        Task<Views> Save(ViewsDto entity);
        Task Update(int id, ViewsDto entity);
    }
}
