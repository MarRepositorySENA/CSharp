using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    internal class Roles_ViewsData : IRoles_ViewsData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public Roles_ViewsData(AplicationDbContext context, IConfiguration configuration)
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
            context.Roles_Views.Update(entity);
            await context.saveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
                    FROM 
                        Roles_Views
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IRoles_ViewsData> GetById(int id)
        {
            var sql = @"SELECT * FROM Roles_Views WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<IRoles_ViewsData>(sql, new { Id = id });

        }

        public async Task<PagedListDto<Roles_ViewsDto>> getDatatable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            IEnumerable<Roles_ViewsDto> items = await context.QueryAsync<Roles_ViewsDto>(sql, new { Filter = filter.Filter });

            var pagedItems = PagedListDto<Roles_ViewsDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<IRoles_ViewsData> Save(IRoles_ViewsData entity)
        {
            context.Roles_Views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(IRoles_ViewsData entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IRoles_ViewsData> GetByCode(string code)
        {
            return await this.context.Roles_Views.AsNoTracking().Where(item => item.Codigo == code).FirstOrDefaultAsync();
        }




    }
}
