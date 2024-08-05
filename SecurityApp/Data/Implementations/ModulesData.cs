using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Context;
using Microsoft.Extensions.Configuration;
using Entity.Model.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Data.Interfaces;

namespace Data.Implementations
{
    public class ModulesData : IModulesData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ModulesData(AplicationDbContext context, IConfiguration configuration)
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
            context.modules.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(code, ' - ', name) AS TextoMostrar 
                    FROM 
                        Modules
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Modules> GetById(int id)
        {
            var sql = @"SELECT * FROM Modules WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Modules>(sql, new { Id = id });
        }

        

        public async Task<Modules> Save(Modules entity)
        {
            context.modules.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Modules entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Modules> GetByCode(string code)
        {
            return await this.context.modules.AsNoTracking().Where(item => item.code == code).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ModulesDto>> SelectAll()
        {
            var sql = @"SELECT 
                Id,
                name,
                description,
                code,
                state,
            FROM 
                Security.Modules
            WHERE deletedAt IS NULL
            ORDER BY Id ASC";

            return await this.context.QueryAsync<ModulesDto>(sql);
        }

    }


}
