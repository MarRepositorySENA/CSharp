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
    public class CityBusiness : ICityBusiness
    {
        private readonly ICityData data;

        public CityBusiness(ICityData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<IEnumerable<City>> SelectAll()
        {
            return await this.data.SelectAll();
        }
        public async Task<CityDto> GetById(int id)
        {
            City city = await this.data.GetById(id);
            CityDto cityDto = new CityDto();
            { 
                cityDto.Id = city.Id;
                cityDto.name = city.name;
                cityDto.description = city.description;
                cityDto.acronym = city.acronym;
                cityDto.state = city.state;

                return cityDto;
            
            }
        }
        public async Task<City> Save(CityDto entity)
        {
            City city = new City();
            city = mapearDatos(city, entity);

            return await this.data.Save(city);
            
        }

       

        public async Task Update(int id, CityDto entity)
        {

            City city = await data.GetById(id);
            if (city == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(city));
            }
            city = this.mapearDatos(city, entity);
            await this.data.Update(city);
        }

        private City mapearDatos (City city, CityDto entity)
        {
            city.Id = entity.Id;
            city.name = entity.name;
            city.description = entity.description;
            city.acronym = entity.acronym;
            city.state = entity.state;

            return city;
        }
    }
}
