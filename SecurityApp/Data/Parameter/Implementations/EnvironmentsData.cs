using Data.Parameter.Interfaces;
using Entity.Context;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Implementations
{
    public class EnvironmentsData : IEnvironmentsData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public EnvironmentsData(AplicationDbContext context, IConfiguration configuration)
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
            context.Environment.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(code) AS TextoMostrar 
                    FROM 
                        Environment
                    WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Environments> GetById(int id)
        {
            var sql = @"SELECT * FROM Environment WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Environments>(sql, new { Id = id });
        }

        public async Task<Environments> Save(Environments entity)
        {
            context.Environment.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Environments entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Environments>> SelectAll()
        {
            var sql = @"SELECT * FROM Environment WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC; ";

            try
            {
                return await context.QueryAsync<Environments>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar la consulta XD", ex);
            }

        }
    }
}
