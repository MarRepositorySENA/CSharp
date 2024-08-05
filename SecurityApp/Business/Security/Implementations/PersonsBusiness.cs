using Business.Security.Interfaces;
using Data.Interfaces;
using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementations
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
            await data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectPersonsDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();

        }
        public async Task<IEnumerable<PersonsDto>> SelectAll()
        {
            return await this.data.SelectAll();
        }


        public async Task<PersonsDto> GetById(int id)
        {
            Persons person = await this.data.GetById(id);
            PersonsDto personDto = new PersonsDto();

            {
                personDto.Id = person.Id;
                personDto.firstName = person.firstName;
                personDto.secondName = person.secondName;
                personDto.email = person.email;
                personDto.gender = person.gender;
                personDto.document = person.document;
                personDto.typeDocument = person.typeDocument;
                personDto.address = person.address;
                personDto.phone = person.phone;
                personDto.birthDate = person.birthDate;

                return personDto;
            };


        }

        public async Task<Persons> Save(PersonsDto entity)
        {
            Persons person = new Persons();
            person = mapearDatos(person, entity);

            return await data.Save(person);
        }

        public async Task Update(int id, PersonsDto entity)
        {
            Persons person = await data.GetById(id);
            if (person == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            person = mapearDatos(person, entity);

            await data.Update(person);
        }

        private Persons mapearDatos(Persons person, PersonsDto entity)
        {
            person.Id = person.Id;
            person.firstName = person.firstName;
            person.secondName = person.secondName;
            person.firstSurname = person.firstSurname;
            person.secondSurname = person.secondSurname;
            person.email = person.email;
            person.gender = person.gender;
            person.document = person.document;
            person.typeDocument = person.typeDocument;
            person.address = person.address;
            person.phone = person.phone;
            person.birthDate = person.birthDate;

            return person;
        }


    }
}
