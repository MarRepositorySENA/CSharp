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
    public class Roles_ViewsBusiness : IRoles_ViewsBusiness
    {
        private readonly IRoles_ViewsData data;

        public Roles_ViewsBusiness(IRoles_ViewsData data)
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
        public async Task<IEnumerable<Roles_ViewsDto>> SelectAll()
        {
            return await this.data.SelectAll();
        }
        public async Task<Roles_ViewsDto> GetById(int id)
        {
            Roles_Views rolView = await this.data.GetById(id);
            Roles_ViewsDto rolViewDto = new Roles_ViewsDto();

            {
                rolViewDto.Id = rolView.Id;
                rolViewDto.roleId = rolView.roleId;
                rolViewDto.viewId = rolView.viewId;
                rolViewDto.state = rolView.state;
                rolViewDto.code = rolView.code;


                return rolViewDto;
            }

        }

        public async Task<Roles_Views> Save(Roles_ViewsDto entity)
        {
            Roles_Views role_view = new Roles_Views();
            role_view = mapearDatos(role_view, entity);

            return await data.Save(role_view);
        }

        public async Task Update(int id, Roles_ViewsDto entity)
        {
            Roles_Views role_view = await data.GetById(id);
            if (role_view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role_view = mapearDatos(role_view, entity);

            await data.Update(role_view);
        }

        private Roles_Views mapearDatos(Roles_Views rolView, Roles_ViewsDto entity)
        {
            rolView.Id = entity.Id;
            rolView.roleId = entity.roleId;
            rolView.viewId = entity.viewId;
            rolView.state = entity.state;
            rolView.code = entity.code;

            return rolView;
        }
    }
}
