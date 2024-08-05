using Data.Interfaces;
using Entity.Model.Context;
using Entity.Model.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    
        public class PersonsData : IPersonsData
        {
            private readonly AplicationDbContext context;
            protected readonly IConfiguration configuration;

            public PersonsData(AplicationDbContext context, IConfiguration configuration)
            {
                this.context = context;
                this.configuration = configuration;
            }

            public async Task Delete(int id)
            {
                var entity = await GetById(id);
                if (entity == null)
                {
                    throw new Exception("Registro no encontrado");
                }
                entity.deletedAt = DateTime.Parse(DateTime.Today.ToString());
                context.persons.Update(entity);
                await context.SaveChangesAsync();
            }

            public async Task<IEnumerable<DataSelectPersonsDto>> GetAllSelect()
            {
                var sql = @"SELECT 
                        Id,
                        CONCAT( firstName, ' - ', secondSurname) AS nombres 
                    FROM 
                        Security.Persons
                    WHERE deletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
                return await this.context.QueryAsync<DataSelectPersonsDto>(sql);
            }

            public async Task<Persons> GetById(int id)
            {
                var sql = @"SELECT * FROM parametro.Persons WHERE Id = @Id ORDER BY Id ASC";
                return await this.context.QueryFirstOrDefaultAsync<Persons>(sql, new { Id = id });
            }



            public async Task<Persons> Save(Persons entity)
            {
                context.persons.Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            public async Task Update(Persons entity)
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
            }

            public async Task<Persons> GetByCode(string code)
            {
                return await this.context.persons.AsNoTracking().Where(item => item.code == code).FirstOrDefaultAsync();
            }

        public async Task<IEnumerable<PersonsDto>> SelectAll()
        {
            var sql = @"SELECT 
                Id,
                firstName,
                secondName,
                firstSurname
                secondSurname,
                email,
                gender,
                document,
                typeDocument,
                address,
                phone,
                birthDate,
            FROM 
                Security.Persons
            WHERE deletedAt IS NULL
            ORDER BY Id ASC";

            return await this.context.QueryAsync<PersonsDto>(sql);
        }

    }
    }

