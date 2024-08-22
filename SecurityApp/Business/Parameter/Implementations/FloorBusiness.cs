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
    public class FloorBusiness : IFloorBusiness
    {
        private readonly IFloorData data;

        public FloorBusiness (IFloorData data)
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

        public async Task<IEnumerable<Floor>> SelectAll()
        {
            return await this.data.SelectAll();
        }

        public async Task<FloorDto> GetById(int id)
        {
            Floor floor = await this.data.GetById(id);
            FloorDto floorDto = new FloorDto();

            floorDto.Id = floor.Id;
            floorDto.code = floor.code;
            floorDto.trainingCenterId = floor.trainingCenterId;

            return floorDto;
        }

        public async Task<Floor> Save(FloorDto entity)
        {
            Floor floor = new Floor();
            floor = mapearDatos (floor, entity);

            return await data.Save(floor);
        }

        public async Task Update(int id, FloorDto entity)
        {
            Floor floor = await data.GetById(id);
            if (floor == null)
            {
                throw new Exception("Registro no encontrado");
            }
            floor = mapearDatos (floor, entity);

            await data.Update(floor);

            
        }

        private Floor mapearDatos (Floor floor, FloorDto entity)
        {
            floor.Id = entity.Id;
            floor.code = entity.code;
            floor.trainingCenterId = entity.trainingCenterId;

            return floor;
        }
    }
}
