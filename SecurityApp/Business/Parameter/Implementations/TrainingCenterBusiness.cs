using Business.Parameter.Interfaces;
using Data.Parameter.Interfaces;
using Entity.Dto.Parameter;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Implementations
{
    public class TrainingCenterBusiness : ITrainingCenterBusiness
    {
        private readonly ITrainingCenterData data;

        public TrainingCenterBusiness (ITrainingCenterData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }
        public async Task<IEnumerable<TrainingCenter>> SelectAll()
        {
            return await this.data.SelectAll();
        }

        public async Task<TrainingCenterDto> GetById(int id)
        {
            TrainingCenter trainingCenter = await this.data.GetById(id);
            TrainingCenterDto  trainingCenterDto = new TrainingCenterDto();

            trainingCenterDto.Id = trainingCenter.Id;
            trainingCenterDto.name = trainingCenter.name;
            trainingCenterDto.acronym = trainingCenter.acronym;
            trainingCenterDto.address = trainingCenter.address;
            trainingCenterDto.state = trainingCenter.state;
            trainingCenterDto.cityId = trainingCenter.cityId;
            trainingCenterDto.regionId = trainingCenter.regionId;

            return trainingCenterDto;
        }

        public async Task<TrainingCenter> Save(TrainingCenterDto entity)
        {
            TrainingCenter trainingCenter = new TrainingCenter();
            trainingCenter = mapearDatos(trainingCenter, entity);

            return await data.Save(trainingCenter);
        }

        public async Task Update(int id, TrainingCenterDto entity)
        {
            TrainingCenter trainingCenter = await data.GetById(id);
            if (trainingCenter == null)
            {
                throw new Exception("Registro no encontrado");
            }
            trainingCenter = mapearDatos (trainingCenter, entity);
            await data.Update(trainingCenter);
        }

        private TrainingCenter mapearDatos( TrainingCenter trainingCenter, TrainingCenterDto entity )
        {
            trainingCenter.Id = entity.Id;
            trainingCenter.name = entity.name;
            trainingCenter.state = entity.state;
            trainingCenter.address = entity.address;
            trainingCenter.state = entity.state;
            trainingCenter.cityId = entity.cityId;
            trainingCenter.regionId = entity.regionId;

            return trainingCenter;

        }
    }
}
