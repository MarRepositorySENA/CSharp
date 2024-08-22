using Entity.Dto.Parameter;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Interfaces
{
    public interface IDepartmentBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Department>> SelectAll();
        Task<DepartmentDto> GetById(int id);
        Task<Department> Save(DepartmentDto entity);
        Task Update(int id, DepartmentDto entity);
    }
}
