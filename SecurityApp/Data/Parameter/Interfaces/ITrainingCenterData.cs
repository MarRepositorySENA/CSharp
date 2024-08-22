using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interfaces
{
    public interface ITrainingCenterData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<TrainingCenter>> SelectAll();
        Task<TrainingCenter> GetById(int id);
        Task<TrainingCenter> Save(TrainingCenter entity);
        Task Update(TrainingCenter entity);
        Task<TrainingCenter> GetByAcronym(string acronym);
    }
}
