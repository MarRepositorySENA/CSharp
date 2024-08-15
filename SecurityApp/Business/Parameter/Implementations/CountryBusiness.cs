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
    public class CountryBusiness : ICountryBusiness
    {
        private readonly ICountryData data;
        
        public CountryBusiness(ICountryData data)
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

        public async Task<IEnumerable<Country>> SelectAll()
        {
            return await this.data.SelectAll();
        }
        public async Task<CountryDto> GetById(int id)
        {
            Country country = await this.data.GetById(id);
            CountryDto countryDto = new CountryDto();
            {

                countryDto.Id = country.Id;
                countryDto.name = country.name;
                countryDto.description = country.description;
                countryDto.acronym = country.acronym;
                countryDto.state = country.state;


                return countryDto;
            }

        }

        public async Task<Country> Save(CountryDto entity)
        {
            Country country = new Country();
            country = mapearDatos(country, entity);

            return await data.Save(country);
        }


        public async Task Update(int id, CountryDto entity)
        {
            Country country = await data.GetById(id);
            if (country == null) {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));

            }
            country = this.mapearDatos(country, entity);
            await data.Update(country);

        }

        private Country mapearDatos(Country country, CountryDto entity)
            {
                country.Id = entity.Id;
                country.name = entity.name;
                country.description = entity.description;
                country.acronym = entity.acronym;
                country.state = entity.state;

                return country;
            }
        
    }
}
