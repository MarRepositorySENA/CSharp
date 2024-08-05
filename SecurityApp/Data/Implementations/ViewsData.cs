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
    public class ViewsData : IViewsData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ViewsData(AplicationDbContext context, IConfiguration configuration)
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
            context.views.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(code, ' - ', name) AS TextoMostrar 
                    FROM 
                        Security.Views
                    WHERE deletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Views> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.Views WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Views>(sql, new { Id = id });
        }



        public async Task<Views> Save(Views entity)
        {
            context.views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Views entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Views> GetByCode(string code)
        {
            return await this.context.views.AsNoTracking().Where(item => item.code == code).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ViewsDto>> SelectAll()
        {
            var sql = @"SELECT 
                                v.Id,
                                v.name,
                                v.description,
                                v.route,
                                v.moduleId,
                                v.state,
                                v.code,
                                 
                        FROM 
                                Security.Views v
                        INNER JOIN 
                                Security.Modules m ON v.moduleId = m.Id
                        WHERE 
                                v.deletedAt IS NULL
                        ORDER BY 
                                 v.Id ASC";

            try
            {
                return await this.context.QueryAsync<ViewsDto>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar la consulta", ex);
            }
        }
    }
}

