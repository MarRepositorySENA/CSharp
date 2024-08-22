using Data.Parameter.Interfaces;
using Entity.Context;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Implementations
{
    public class DepartmentData : IDepartmentData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public DepartmentData(AplicationDbContext context, IConfiguration configuration)
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
            context.Departments.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(acronym, ' - ', name) AS TextoMostrar 
                    FROM 
                        Deparments
                    WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }



        public async Task<Department> GetById(int id)
        {
            var sql = @"SELECT * FROM Deparments WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Department>(sql, new { Id = id });
        }

        public async Task<Department> Save(Department entity)
        {
            context.Departments.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Department entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<Department> GetByAcronym(string acronym)
        {
            return await context.Departments.AsNoTracking().Where(item => item.acronym == acronym).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Department>> SelectAll()
        {
            var sql = @"SELECT * FROM Departments WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC; ";

            try
            {
                return await context.QueryAsync<Department>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar la consulta XD", ex);
            }
        }

        
    }
}
