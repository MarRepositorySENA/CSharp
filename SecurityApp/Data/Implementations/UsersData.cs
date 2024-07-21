using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    internal class UsersData: IUsersData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public UsersData(AplicationDbContext context, IConfiguration configuration) 
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
            context.Users.Update(entity);
            await context.saveChangesAsync();
        }

        public async Task <IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
                    FROM 
                        Users
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Users> GetById(int id)
        {
            var sql = @"SELECT * FROM Users WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Users>(sql, new { Id = id });

        }

        public async Task<PagedListDto<UsersDto>> getDatatable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

          ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            IEnumerable<UsersDto> items = await context.QueryAsync<UsersDto>(sql, new { Filter = filter.Filter });

            var pagedItems = PagedListDto<UsersDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<Users> Save(Users entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Users entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Users> GetByCode(string code)
        {
            return await this.context.Users.AsNoTracking().Where(item => item.Codigo == code).FirstOrDefaultAsync();
        }




    }
}
