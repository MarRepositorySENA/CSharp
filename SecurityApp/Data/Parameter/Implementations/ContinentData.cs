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
    public class ContinentData : IContinentData
    {

        private readonly AplicationDbContext _context;
        private readonly IConfiguration configuration;


        public ContinentData(AplicationDbContext context, IConfiguration configuration)
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
            _context.Continents.Update(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(acronym, ' - ', name) AS TextoMostrar 
                    FROM 
                        Continents
                    WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await _context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Continent> GetById(int id)
        {
            var sql = @"SELECT * FROM Continents WHERE Id = @Id ORDER BY Id ASC";
            return await _context.QueryFirstOrDefaultAsync<Continent>(sql, new { Id = id });
        }

        public async Task<Continent> Save(Continent entity)
        {
            _context.Continents.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Continent entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Continent>> SelectAll()
        {
            var sql = @"SELECT * FROM Continents  WHERE deletedAt IS NULL AND state = 1
                    ORDER BY Id ASC";


            try
            {
                return await _context.QueryAsync<Continent>(sql);
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new ApplicationException("Error al ejecutar la consulta SelectAll() XD", ex);
            }
        }
        public async Task<Continent> GetByAcronym(string acronym)
        {
            return await _context.Continents.AsNoTracking().Where(item => item.acronym == acronym).FirstOrDefaultAsync();
        }


    }
}
