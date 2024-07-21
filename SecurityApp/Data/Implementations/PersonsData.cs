using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    internal class PersonsData : IPersonsData
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
            entity.DeleteAt = DateTime.Parse(DateTime.Today.ToString());
            context.Persons.Update(entity);
            await context.saveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
                    FROM 
                        Persons
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Persons> GetById(int id)
        {
            var sql = @"SELECT * FROM Persons WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Persons>(sql, new { Id = id });

        }

        public async Task<PagedListDto<PersonsDto>> getDatatable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            IEnumerable<PersonsDto> items = await context.QueryAsync<PersonsDto>(sql, new { Filter = filter.Filter });

            var pagedItems = PagedListDto<PersonsDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<Persons> Save(Persons entity)
        {
            context.Persons.Add(entity);
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
            return await this.context.Persons.AsNoTracking().Where(item => item.Codigo == code).FirstOrDefaultAsync();
        }




    }
}
