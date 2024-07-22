using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IModulesData
    {
        public ModuleData(ApplicationDbContext context, IConfiguration configuration);
        public async Task Delete(int id);
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public async Task<Module> GetById(int id);
        public async Task<Module> Save(Module entity);
        public async Task Update(Module entity);
        public async Task<Module> GetByCode(string code);


    }
}
