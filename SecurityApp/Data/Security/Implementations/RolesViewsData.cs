﻿using Data.Security.Interfaces;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Implementations
{
    public class RolesViewsData : IRolesViewsData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RolesViewsData(AplicationDbContext context, IConfiguration configuration)
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
            context.RolesViews.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                                rV.Id,
                                CONCAT(r.name, ' - ', v.name) AS TextoMostrar 
                        FROM 
                                RolesViews rV
                        INNER JOIN 
                                Roles r ON rV.roleId = r.Id
                        INNER JOIN 
                                Views v ON rV.viewId = v.Id
                        WHERE 
                              rV.deletedAt IS NULL AND  rV.state = 1
                        ORDER BY 
                                rV.Id ASC; ";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<RoleView> GetById(int id)
        {
            var sql = @"SELECT * FROM RolesViews WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<RoleView>(sql, new { Id = id });
        }



        public async Task<RoleView> Save(RoleView entity)
        {
            context.RolesViews.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(RoleView entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }



        public async Task<IEnumerable<RoleView>> SelectAll()
        {
            var sql = @"SELECT * FROM RolesViews WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC; ";


            try
            {
                return await context.QueryAsync<RoleView>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar la consulta XD", ex);
            }
        }

        public async Task<MenuDto> Menu(int id)
        {
            var sql = @"SELECT 
        v.name AS ViewName, 
        m.name AS ModuleName, 
        v.Id AS viewId,
        m.Id AS moduleId
        FROM RolesViews AS rv
        INNER JOIN Views AS v ON v.id = rv.viewId
        INNER JOIN Modules AS m ON m.id = v.moduleId
        WHERE rv.Id = @Id;";

            return await context.QueryFirstOrDefaultAsync<MenuDto>(sql, new { Id = id });
        }

    }
}
