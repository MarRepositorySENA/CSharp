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
    public class Roles_ViewsBusiness : IRoles_ViewsBusiness
    {
        private readonly IRoles_ViewsData data;

        public Roles_ViewsBusiness(IRoles_ViewsData data)
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

        public async Task<Roles_ViewsDto> GetById(int id)
        {
            Roles_Views role_view = await this.data.GetById(id);
            Roles_ViewsDto Roles_ViewsDto = new Roles_ViewsDto();
            /*
            Roles_ViewsDto.Id = role_view.Id;
            Roles_ViewsDto.Codigo = role_view.Codigo;
            Roles_ViewsDto.Nombre = role_view.Nombre;
            Roles_ViewsDto.DepartamentoId = role_view.DepartamentoId;
            Roles_ViewsDto.Estado = role_view.Estado;
            */

            return Roles_ViewsDto;
        }

        public async Task<Roles_Views> Save(Roles_ViewsDto entity)
        {
            Roles_Views role_view = new Roles_Views();
            role_view = this.mapearDatos(role_view, entity);

            return await this.data.Save(role_view);
        }

        public async Task Update(int id, Roles_ViewsDto entity)
        {
            Roles_Views role_view = await this.data.GetById(id);
            if (role_view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role_view = this.mapearDatos(role_view, entity);

            await this.data.Update(role_view);
        }

        private Roles_Views mapearDatos(Roles_Views role_view, Roles_ViewsDto entity)
        {
            /*
            role_view.Id = entity.Id;
            role_view.Codigo = entity.Codigo;
            role_view.Nombre = entity.Nombre;
            role_view.DepartamentoId = entity.DepartamentoId;
            role_view.Estado = entity.Estado;
            */
            return role_view;
        }
    }
}
