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
    public class EnvironmentsBusiness : IEnvironmentsBusiness
    {
        private readonly IEnvironmentsData data;

        public EnvironmentsBusiness(IEnvironmentsData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<IEnumerable<Environments>> SelectAll()
        {
            return await this.data.SelectAll();
        }



        public async Task<EnvironmentsDto> GetById(int id)
        {
            Environments environments = await this.data.GetById(id);
            EnvironmentsDto environmentsDto = new EnvironmentsDto();

            environmentsDto.Id = environments.Id;
            environmentsDto.code = environments.code;
            environmentsDto.floorId = environments.floorId;
            environmentsDto.specialtyId = environments.specialtyId;

            return environmentsDto;

        }
        public async Task<Environments> Save(EnvironmentsDto entity)
        {
            Environments environments = new Environments();
            environments = mapearDatos(environments, entity);

            return await data.Save(environments);
        }

        public async Task Update(int id, EnvironmentsDto entity)
        {
            Environments environments = await data.GetById(id);
            if (environments == null)
            {
                throw new Exception("Registro no encontrado");
            }
            environments = mapearDatos(environments, entity);
            await data.Update(environments);
            
        }
         
        private Environments mapearDatos(Environments environments, EnvironmentsDto entity)
        {   
            environments.Id = entity.Id;
            environments.code = entity.code;
            environments.floorId = entity.floorId;
            environments.specialtyId= entity.specialtyId;

            return environments;
        }

    }
}
