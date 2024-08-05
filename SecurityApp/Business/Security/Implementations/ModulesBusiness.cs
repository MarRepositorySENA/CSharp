using Entity.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implementations;



using Entity.Model.Security;
using Data.Interfaces;
using Business.Security.Interfaces;

namespace Business.Security.Implementations
{
    public class ModulesBusiness : IModulesBusiness
    {
        private readonly IModulesData data;

        public ModulesBusiness(IModulesData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

     

        public async Task<IEnumerable<ModulesDto>> SelectAll()
        {
            return await this.data.SelectAll();
        }

        public async Task<ModulesDto> GetById(int id)
        {
            Modules module = await this.data.GetById(id);
            ModulesDto moduleDto = new ModulesDto();

            {
                moduleDto.Id = module.Id;
                moduleDto.name = module.name;
                moduleDto.description = module.description;
                moduleDto.state = module.state;
                moduleDto.code = module.code;

                return moduleDto;
            }

        }

        public async Task<Modules> Save(ModulesDto entity)
        {
            Modules module = new Modules();
            module = mapearDatos(module, entity);

            return await data.Save(module);
        }

        public async Task Update(int id, ModulesDto entity)
        {
            Modules module = await data.GetById(id);
            if (module == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            module = this.mapearDatos(module, entity);

            await this.data.Update(module);
        }

        private Modules mapearDatos(Modules module, ModulesDto entity)
        {
            module.Id = entity.Id;
            module.name = entity.name;
            module.description = entity.description;
            module.state = entity.state;
            module.code = entity.code;


            return module;
        }
    }
}
