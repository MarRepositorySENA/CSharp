using Data.Parameter.Interfaces;
using Entity.Context;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Implementations
{
    public class CityData : ICityData
    {
        private readonly AplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CityData(AplicationDbContext context, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._context = context;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deletedAt = DateTime.Parse(DateTime.Today.ToString());
            _context.Cities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(acronym, ' - ', name) AS TextoMostrar 
                    FROM 
                        Cities
                    WHERE DeletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await _context.QueryAsync<DataSelectDto>(sql);
        }

       

        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM Cities WHERE Id = @Id ORDER BY Id ASC";
            return await _context.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }

        public async Task<City> Save(City entity)
        {
            _context.Cities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(City entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> SelectAll()
        {
            var sql = @"SELECT * FROM Cities  WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";


            try
            {
                return await _context.QueryAsync<City>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar el metodo SelectAll XD", ex);
            }
        }

        public async Task<City> GetByAcronym(string acronym)
        {
            return await _context.Cities.AsNoTracking().Where(item => item.acronym == acronym).FirstOrDefaultAsync();
        }
    }
}
