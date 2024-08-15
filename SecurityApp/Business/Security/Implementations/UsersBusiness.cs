using Business.Security.Interfaces;
using Data.Security.Interfaces;
using Entity.Dao;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementations
{
    public class UsersBusiness : IUsersBusiness
    {
        private readonly IUsersData data;
        private readonly IRolesViewsData rolViewData;

        public UsersBusiness(IUsersData data, IRolesViewsData roleViewData)
        {
            this.data = data;
            this.rolViewData = roleViewData;
            
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<IEnumerable<User>> SelectAll()
        {
            return await this.data.SelectAll();
        }

        public async Task<UsersDto> GetById(int id)
        {
            var user = await data.GetById(id);

            return new UsersDto
            {
                Id = user.Id,
                username = user.username,
                password = user.password,
                personId = user.personId,
                state = user.state,
                

            };

        }

        public async Task<User> Save(UsersDto entity)
        {
            User user = new User();
            user = mapearDatos(user, entity);

            return await data.Save(user);
        }

        public async Task Update(int id, UsersDto entity)
        {
            User user = await data.GetById(id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = mapearDatos(user, entity);

            await data.Update(user);
        }

        private User mapearDatos(User user, UsersDto entity)
        {
            user.Id = entity.Id;
            user.username = entity.username;
            user.password = entity.password;
            user.personId = entity.personId;
            user.state = entity.state;
            



            return user;
        }

        public async Task<(LoginDao loginDao, MenuDto menuDto)> Login(string username, string password)
        {
            LoginDto userl = await data.Login(username, password);
            if (userl == null)
            {
                throw new Exception("Usuario o contraseña incorrectos");
            }

            LoginDao loginDao = new LoginDao
            {
                Id = userl.Id,
                roleId = userl.RoleId
            };

            MenuDto menuDto = await rolViewData.Menu(loginDao.roleId);

            return (loginDao, menuDto);
            
        }
    }
}
