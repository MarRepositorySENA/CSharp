using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interfaces
{
    public interface IDepartmentData
    {

        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<Department>> SelectAll();
        Task<Department> GetById(int id);
        Task<Department> Save(Department entity);
        Task Update(Department entity);
        Task<Department> GetByAcronym(string acronym);
    }
}
