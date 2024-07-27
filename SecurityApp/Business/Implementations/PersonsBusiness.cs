using Business.Interfaces;
using Data.Interfaces;
using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class PersonsBusiness : IPersonsBusiness
    {
        private readonly IPersonsData data;

        public PersonsBusiness(IPersonsData data)
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

        public async Task<PersonsDto> GetById(int id)
        {
            Persons person = await this.data.GetById(id);
            PersonsDto PersonsDto = new PersonsDto();
            /*
            PersonsDto.Id = person.Id;
            PersonsDto.Codigo = person.Codigo;
            PersonsDto.Nombre = person.Nombre;
            PersonsDto.DepartamentoId = person.DepartamentoId;
            PersonsDto.Estado = person.Estado;
            */

            return PersonsDto;
        }

        public async Task<Persons> Save(PersonsDto entity)
        {
            Persons person = new Persons();
            person = this.mapearDatos(person, entity);

            return await this.data.Save(person);
        }

        public async Task Update(int id, PersonsDto entity)
        {
            Persons person = await this.data.GetById(id);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = this.mapearDatos(person, entity);

            await this.data.Update(person);
        }

        private Persons mapearDatos(Persons person, PersonsDto entity)
        {
            /*
            person.Id = entity.Id;
            person.Codigo = entity.Codigo;
            person.Nombre = entity.Nombre;
            person.DepartamentoId = entity.DepartamentoId;
            person.Estado = entity.Estado;
            */
            return person;
        }
    }
}
