using Business.Interfaces;
using Data.Interfaces;
using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class RolesBusiness : IRolesBusiness
    {
        private readonly IRolesData data;

        public RolesBusiness(IRolesData data)
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

        public async Task<RolesDto> GetById(int id)
        {
            Roles role = await this.data.GetById(id);
            RolesDto RolesDto = new RolesDto();
            /*
            RolesDto.Id = role.Id;
            RolesDto.Codigo = role.Codigo;
            RolesDto.Nombre = role.Nombre;
            RolesDto.DepartamentoId = role.DepartamentoId;
            RolesDto.Estado = role.Estado;
            */

            return RolesDto;
        }

        public async Task<Roles> Save(RolesDto entity)
        {
            Roles role = new Roles();
            role = this.mapearDatos(role, entity);

            return await this.data.Save(role);
        }

        public async Task Update(int id, RolesDto entity)
        {
            Roles role = await this.data.GetById(id);
            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role = this.mapearDatos(role, entity);

            await this.data.Update(role);
        }

        private Roles mapearDatos(Roles role, RolesDto entity)
        {
            /*
            role.Id = entity.Id;
            role.Codigo = entity.Codigo;
            role.Nombre = entity.Nombre;
            role.DepartamentoId = entity.DepartamentoId;
            role.Estado = entity.Estado;
            */
            return role;
        }
    }
}
