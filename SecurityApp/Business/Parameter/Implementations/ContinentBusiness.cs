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
    public class ContinentBusiness : IContinentBusiness
    {
        private readonly IContinentData data;
        
        public ContinentBusiness (IContinentData data)
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
        public async Task<IEnumerable<Continent>> SelectAll()
        {
            return await this.data.SelectAll();
        }
        public async Task<ContinentDto> GetById(int id)
        {
            Continent continent = await this.data.GetById(id);
            ContinentDto continentDto = new ContinentDto();

            continentDto.Id = continent.Id;
            continentDto.name = continent.name;
            continentDto.description = continent.description;
            continentDto.acronym = continent.acronym;
            continentDto.state = continent.state;

            return continentDto;
        }

        public async Task<Continent> Save(ContinentDto entity)
        {
            Continent continent = new Continent();
            continent = mapearDatos(continent, entity);

            return await data.Save(continent);
            
        }

        public async Task Update(int id, ContinentDto entity)
        {
            Continent continent = await this.data.GetById(id);
            if (continent == null)
            {
                throw new ArgumentNullException("Registro no encontrado",nameof(continent));
            }
            continent = this.mapearDatos(continent, entity);

            await this.data.Update(continent);
        }

        private Continent mapearDatos(Continent continent, ContinentDto entity)
        {
            continent.Id= entity.Id;
            continent.name = entity.name;
            continent.description = entity.description;
            continent.acronym = entity.acronym;
            continent.state = entity.state;
            return continent;
        }
    }
}
