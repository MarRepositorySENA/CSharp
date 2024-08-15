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
    public class CountryData : ICountryData
    {

        private readonly AplicationDbContext _context;
        protected readonly IConfiguration configuration;

        public CountryData(AplicationDbContext context, IConfiguration configuration)
        {
            this._context = context;
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
            _context.Countries.Update(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(acronym, ' - ', name) AS TextoMostrar 
                    FROM
                           Countries
                    WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await _context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Country> GetById(int id)
        {
            var sql = @"SELECT * FROM Countries WHERE Id = @Id ORDER BY Id ASC";
            return await _context.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });

        }

        public async Task<Country> Save(Country entity)
        {
            _context.Countries.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

     

        public async Task Update(Country entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<Country>> SelectAll()
        {
            var sql = @"SELECT * FROM Countries  WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";


            try
            {
                return await _context.QueryAsync<Country>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar la consulta XD", ex);
            }

        }

        public async Task<Country> GetByAcronym(string acronym)
        {
            return await _context.Countries.AsNoTracking().Where(item => item.acronym == acronym).FirstOrDefaultAsync();
        }
    }
}
