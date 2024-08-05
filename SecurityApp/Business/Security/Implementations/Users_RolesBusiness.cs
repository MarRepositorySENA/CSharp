using Business.Security.Interfaces;
using Data.Interfaces;
using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementations
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
            await data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<IEnumerable<Users_RolesDto>> SelectAll()
        {
            return await this.data.SelectAll();
        }


        public async Task<Users_RolesDto> GetById(int id)
        {
            Users_Roles userRol = await this.data.GetById(id);
            Users_RolesDto users_rolesDto = new Users_RolesDto();

            {
                users_rolesDto.Id = userRol.Id;
                users_rolesDto.userId = userRol.userId;
                users_rolesDto.roleId = userRol.roleId;
                users_rolesDto.state = userRol.state;
                users_rolesDto.code = userRol.code;
                users_rolesDto.state = userRol.state;

                return users_rolesDto;
            }

        }

        public async Task<Users_Roles> Save(Users_RolesDto entity)
        {
            Users_Roles user_role = new Users_Roles();
            user_role = mapearDatos(user_role, entity);

            return await data.Save(user_role);
        }

        public async Task Update(int id, Users_RolesDto entity)
        {
            Users_Roles user_role = await data.GetById(id);
            if (user_role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user_role = mapearDatos(user_role, entity);

            await data.Update(user_role);
        }


        private Users_Roles mapearDatos(Users_Roles userRol, Users_RolesDto entity)
        {
            userRol.Id = entity.Id;
            userRol.userId = entity.userId;
            userRol.roleId = entity.roleId;
            userRol.state = entity.state;
            userRol.code = entity.code;
            

            return userRol;
        }
    }
}
