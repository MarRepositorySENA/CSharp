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
    public class UsersBusiness : IUsersBusiness
    {
        private readonly IUsersData data;

        public UsersBusiness(IUsersData data)
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

        public async Task<UsersDto> GetById(int id)
        {
            Users user = await this.data.GetById(id);
            UsersDto UsersDto = new UsersDto();
            /*
            UsersDto.Id = user.Id;
            UsersDto.Codigo = user.Codigo;
            UsersDto.Nombre = user.Nombre;
            UsersDto.DepartamentoId = user.DepartamentoId;
            UsersDto.Estado = user.Estado;
            */

            return UsersDto;
        }

        public async Task<Users> Save(UsersDto entity)
        {
            Users user = new Users();
            user = this.mapearDatos(user, entity);

            return await this.data.Save(user);
        }

        public async Task Update(int id, UsersDto entity)
        {
            Users user = await this.data.GetById(id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = this.mapearDatos(user, entity);

            await this.data.Update(user);
        }

        private Users mapearDatos(Users user, UsersDto entity)
        {
            /*
            user.Id = entity.Id;
            user.Codigo = entity.Codigo;
            user.Nombre = entity.Nombre;
            user.DepartamentoId = entity.DepartamentoId;
            user.Estado = entity.Estado;
            */
            return user;
        }
    }
}
