﻿using Data.Interfaces;
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
    public class UsersData : IUsersData
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
            entity.deletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.users.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        username AS TextoMostrar 
                    FROM 
                        Security.Users
                    WHERE deletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Users> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.Users WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Users>(sql, new { Id = id });
        }



        public async Task<Users> Save(Users entity)
        {
            context.users.Add(entity);
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
            return await this.context.users.AsNoTracking().Where(item => item.code == code).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UsersDto>> SelectAll()
        {
            var sql = @"SELECT 
                Id,
                u.username,
                u.password,
                u.personId,
                u.state,
                u.code,
                p.firstName
            FROM 
                Security.Users
            INNER JOIN
                Security.Persons p ON u.personId = p.Id
            WHERE 
                deletedAt IS NULL
            ORDER BY 
                u.Id ASC";

            return await this.context.QueryAsync<UsersDto>(sql);
        }
    }
}
