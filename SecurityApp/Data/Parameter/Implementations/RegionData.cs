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
    public class RegionData : IRegionData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RegionData(AplicationDbContext context, IConfiguration configuration)
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
            context.Regions.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {

            var sql = @"SELECT 
                        Id,
                        CONCAT(acronym, ' - ', name) AS TextoMostrar 
                    FROM 
                        Views
                    WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        
        public async Task<Region> GetById(int id)
        {
            var sql = @"SELECT * FROM Regions WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Region>(sql, new { Id = id });
        }

        public async Task<Region> Save(Region entity)
        {
            context.Regions.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Region entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Region>> SelectAll()
        {
            var sql = @"SELECT * FROM Regions WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC; ";

            try
            {
                return await context.QueryAsync<Region>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar la consulta XD", ex);
            }
        }

        public async Task<Region> GetByAcronym(string acronym)
        {
            return await context.Regions.AsNoTracking().Where(item => item.acronym == acronym).FirstOrDefaultAsync();
        }
    }
}
