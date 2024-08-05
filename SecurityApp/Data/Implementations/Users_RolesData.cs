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
    public class Users_RolesData : IUsers_RolesData
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
            entity.deletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.users_roles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        code AS TextoMostrar 
                    FROM 
                        Security.Users_Roles
                    WHERE deletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Users_Roles> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.Users_Roles WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Users_Roles>(sql, new { Id = id });
        }



        public async Task<Users_Roles> Save(Users_Roles entity)
        {
            context.users_roles.Add(entity);
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
            return await this.context.users_roles.AsNoTracking().Where(item => item.code == code).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Users_RolesDto>> SelectAll()
        {
            var sql = @"SELECT 
                Id,
                roleId,
                userId,
                state,
                code,
            FROM 
                Security.Users_Roles
            WHERE deletedAt IS NULL
            ORDER BY Id ASC";

            return await this.context.QueryAsync<Users_RolesDto>(sql);
        }
    }
}
