using Entity.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implementations;



using Entity.Model.Security;
using Data.Interfaces;
using Business.Interfaces;

namespace Business.Implementations
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

        /*
        public async Task<ModulesDto> GetById(int id)
        {
            Modules module = await this.data.GetById(id);
            ModulesDto ModulesDto = new ModulesDto();
            {
                Id = module.id;
                Name = module.name;
                Description = module.description;
                Code = module.code;
                State = module.state;
                CreatedAt = module.createdAt;
                CreatedBy = module.createdBy;
                UpdatedAt = module.updatedAt
                UpdatedBy = module.updatedBy,
                DeletedAt = module.deletedAt,
                DeletedBy = module.deletedBy
            };
           

            return ModulesDto;
        
        }*/

        public async Task<Modules> Save(ModulesDto entity)
        {
            Modules module = new Modules();
            module = this.mapearDatos(module, entity);

            return await this.data.Save(module);
        }

        public async Task Update(int id, ModulesDto entity)
        {
            Modules module = await this.data.GetById(id);
            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }
            module = this.mapearDatos(module, entity);

            await this.data.Update(module);
        }

        private Modules mapearDatos(Modules module, ModulesDto entity)
        {

            /*
            module.Id = entity.Id;
            module.Codigo = entity.Codigo;
            module.Nombre = entity.Nombre;
            module.DepartamentoId = entity.DepartamentoId;
            module.Estado = entity.Estado;
            */
            return module;
        }
    }
}
