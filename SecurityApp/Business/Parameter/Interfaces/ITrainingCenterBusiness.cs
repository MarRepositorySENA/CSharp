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
    public interface ITrainingCenterBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<TrainingCenter>> SelectAll();
        Task<TrainingCenterDto> GetById(int id);
        Task<TrainingCenter> Save(TrainingCenterDto entity);
        Task Update(int id, TrainingCenterDto entity);
    }
}
