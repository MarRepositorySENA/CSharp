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
    public class RolesData : IRolesData
    {

        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RolesData(AplicationDbContext context, IConfiguration configuration)
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
            context.roles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(code, ' - ', name) AS TextoMostrar 
                    FROM 
                        Security.Roles
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Roles> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.Roles WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Roles>(sql, new { Id = id });
        }



        public async Task<Roles> Save(Roles entity)
        {
            context.roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Roles entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Roles> GetByCode(string code)
        {
            return await this.context.roles.AsNoTracking().Where(item => item.code == code).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<RolesDto>> SelectAll()
        {
            var sql = @"SELECT 
                Id,
                name,
                description,
                code,
                state,
            FROM 
                Security.Roles
            WHERE deletedAt IS NULL
            ORDER BY Id ASC";

            return await this.context.QueryAsync<RolesDto>(sql);
        }
    }
}
