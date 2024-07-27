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
    public class ViewsBusiness
    {
        private readonly IViewsData data;

        public ViewsBusiness(IViewsData data)
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

        public async Task<ViewsDto> GetById(int id)
        {
            Views view = await this.data.GetById(id);
            ViewsDto ViewsDto = new ViewsDto();
            /*
            ViewsDto.Id = view.Id;
            ViewsDto.Codigo = view.Codigo;
            ViewsDto.Nombre = view.Nombre;
            ViewsDto.DepartamentoId = view.DepartamentoId;
            ViewsDto.Estado = view.Estado;
            */

            return ViewsDto;
        }

        public async Task<Views> Save(ViewsDto entity)
        {
            Views view = new Views();
            view = this.mapearDatos(view, entity);

            return await this.data.Save(view);
        }

        public async Task Update(int id, ViewsDto entity)
        {
            Views view = await this.data.GetById(id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            view = this.mapearDatos(view, entity);

            await this.data.Update(view);
        }

        private Views mapearDatos(Views view, ViewsDto entity)
        {
            /*
            view.Id = entity.Id;
            view.Codigo = entity.Codigo;
            view.Nombre = entity.Nombre;
            view.DepartamentoId = entity.DepartamentoId;
            view.Estado = entity.Estado;
            */
            return view;
        }
    }
}
