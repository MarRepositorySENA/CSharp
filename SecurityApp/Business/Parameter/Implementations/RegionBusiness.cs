using Business.Parameter.Interfaces;
using Data.Parameter.Interfaces;
using Entity.Dto.Parameter;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Implementations
{
    public class RegionBusiness : IRegionBusiness
    {
        private readonly IRegionData data;

        public RegionBusiness(IRegionData data)
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

        public async Task<IEnumerable<Region>> SelectAll()
        {
            return await data.SelectAll();
        }

        public async Task<RegionDto> GetById(int id)
        {
            Region region = await this.data.GetById(id);
            RegionDto regionDto = new RegionDto();  

            regionDto.Id = region.Id;
            regionDto.name = region.name;
            regionDto.acronym = region.acronym;
            regionDto.state = region.state;
            regionDto.departamentId = region.departamentId;

            return regionDto;
        }

        public async Task<Region> Save(RegionDto entity)
        {
            Region region = new Region();
            region = mapearDatos (region, entity);

            return await data.Save(region);
        }

        public async Task Update(int id, RegionDto entity)
        {
            Region region = await data.GetById(id);
            if (region == null)
            {
                throw new Exception("Registro no encontrado");
            }
            region = mapearDatos (region, entity);
            await data.Update(region);
        }

        private Region mapearDatos(Region region, RegionDto entity)
        {
            region.Id = entity.Id;
            region.name = entity.name;
            region.acronym = entity.acronym;
            region.state = entity.state;
            region.departamentId = entity.departamentId;

            return region;
        }
    }
}
