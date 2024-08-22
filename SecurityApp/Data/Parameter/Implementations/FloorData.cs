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
    public class FloorData : IFloorData
    {
        private readonly AplicationDbContext context;
        private readonly IConfiguration configuration;

        public FloorData(AplicationDbContext context, IConfiguration configuration)
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
            context.Floors.Update(entity);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        code AS TextoMostrar 
                    FROM 
                        Views
                    WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Floor> GetById(int id)
        {
            var sql = @"SELECT * FROM Floors WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Floor>(sql, new { Id = id });
        }

        public async Task<Floor> Save(Floor entity)
        {
            context.Floors.Add(entity);
            await context.SaveChangesAsync();
            return entity;

        }

       

        public async Task Update(Floor entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
       
        public async Task<IEnumerable<Floor>> SelectAll()
        {
            var sql = @"SELECT * FROM Floors WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC; ";

            try
            {
                return await context.QueryAsync<Floor>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar la consulta XD", ex);
            }

        }
    }
}
