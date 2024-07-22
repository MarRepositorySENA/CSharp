using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Implementation
{
    public class ModuleData : IModuleData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ModuleData(ApplicationDbContext context, IConfiguration configuration)
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
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Module.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
                    FROM 
                        Modules
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Module> GetById(int id)
        {
            var sql = @"SELECT * FROM parametro.Module WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Module>(sql, new { Id = id });
        }

        

        public async Task<Module> Save(Module entity)
        {
            context.Module.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Module entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Module> GetByCode(string code)
        {
            return await this.context.Module.AsNoTracking().Where(item => item.Codigo == code).FirstOrDefaultAsync();
        }
    }
    tiene menú contextual
}
