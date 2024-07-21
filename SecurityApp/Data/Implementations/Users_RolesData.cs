using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    internal class Users_RolesData : IUsers_RolesData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public Users_RolesData(AplicationDbContext context, IConfiguration configuration)
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
            context.Users_Roles.Update(entity);
            await context.saveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
                    FROM 
                        Users_Roles
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Users_Roles> GetById(int id)
        {
            var sql = @"SELECT * FROM Users_Roles WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Users_Roles>(sql, new { Id = id });

        }

        public async Task<PagedListDto<Users_RolesDto>> getDatatable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            IEnumerable<Users_RolesDto> items = await context.QueryAsync<Users_RolesDto>(sql, new { Filter = filter.Filter });

            var pagedItems = PagedListDto<Users_RolesDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<Users_Roles> Save(Users_Roles entity)
        {
            context.Users_Roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Users_Roles entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Users_Roles> GetByCode(string code)
        {
            return await this.context.Users_Roles.AsNoTracking().Where(item => item.Codigo == code).FirstOrDefaultAsync();
        }




    }
}
