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
    public class TrainingCenterData : ITrainingCenterData
    {
        private readonly AplicationDbContext context;
        private readonly IConfiguration configuration;

        public TrainingCenterData(AplicationDbContext context, IConfiguration configuration)
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
            context.TrainingsCenters.Update(entity);
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

        public async Task<TrainingCenter> GetById(int id)
        {
            var sql = @"SELECT * FROM TrainingsCenters WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<TrainingCenter>(sql, new { Id = id });
        }

        public async Task<TrainingCenter> Save(TrainingCenter entity)
        {
            context.TrainingsCenters.Add(entity);
            await context.SaveChangesAsync();
            return entity;

        }
        public async Task Update(TrainingCenter entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<TrainingCenter> GetByAcronym(string acronym)
        {
            return await context.TrainingsCenters.AsNoTracking().Where(item => item.acronym == acronym).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TrainingCenter>> SelectAll()
        {

            var sql = @"SELECT * FROM TrainingsCenters WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC; ";

            try
            {
                return await context.QueryAsync<TrainingCenter>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar la consulta XD", ex);
            }
        }
    }
}