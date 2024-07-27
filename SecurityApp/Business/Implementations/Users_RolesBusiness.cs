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
    public class Users_RolesBusiness : IUsers_RolesBusiness
    {
        private readonly IUsers_RolesData data;

        public Users_RolesBusiness(IUsers_RolesData data)
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

        public async Task<Users_RolesDto> GetById(int id)
        {
            Users_Roles user_role = await this.data.GetById(id);
            Users_RolesDto Users_RolesDto = new Users_RolesDto();
            /*
            Users_RolesDto.Id = user_role.Id;
            Users_RolesDto.Codigo = user_role.Codigo;
            Users_RolesDto.Nombre = user_role.Nombre;
            Users_RolesDto.DepartamentoId = user_role.DepartamentoId;
            Users_RolesDto.Estado = user_role.Estado;
            */

            return Users_RolesDto;
        }

        public async Task<Users_Roles> Save(Users_RolesDto entity)
        {
            Users_Roles user_role = new Users_Roles();
            user_role = this.mapearDatos(user_role, entity);

            return await this.data.Save(user_role);
        }

        public async Task Update(int id, Users_RolesDto entity)
        {
            Users_Roles user_role = await this.data.GetById(id);
            if (user_role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user_role = this.mapearDatos(user_role, entity);

            await this.data.Update(user_role);
        }

        private Users_Roles mapearDatos(Users_Roles user_role, Users_RolesDto entity)
        {
            /*
            user_role.Id = entity.Id;
            user_role.Codigo = entity.Codigo;
            user_role.Nombre = entity.Nombre;
            user_role.DepartamentoId = entity.DepartamentoId;
            user_role.Estado = entity.Estado;
            */
            return user_role;
        }
    }
}
