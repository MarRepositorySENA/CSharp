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
    public class DepartmentBusiness : IDepartmentBusiness
    {
        private readonly IDepartmentData data;

        public DepartmentBusiness(IDepartmentData data)
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
        public async Task<IEnumerable<Department>> SelectAll()
        {
            return await this.data.SelectAll();
        }

        public async Task<DepartmentDto> GetById(int id)
        {
            Department department = await this.data.GetById(id);
            DepartmentDto departmentDto = new DepartmentDto();

            departmentDto.Id = department.Id;
            departmentDto.name = department.name;
            departmentDto.description = department.description;
            departmentDto.acronym = department.acronym;
            departmentDto.state = department.state;

            return departmentDto;

        }

        public async Task<Department> Save(DepartmentDto entity)
        {
            Department department = new Department();
            department = mapearDatos (department, entity);

            return await data.Save(department);
        }

        public async Task Update(int id, DepartmentDto entity)
        {
            Department department = await data.GetById(id);
            if (department == null) 
            {
                throw new Exception("Registro no encontrado");
            }
            department = mapearDatos(department, entity);
            await data.Update(department);
            
        }

        private Department mapearDatos(Department department, DepartmentDto entity)
        {
            department.Id = entity.Id;
            department.name = entity.name;
            department.description = entity.description;
            department.acronym = entity.acronym;
            department.state = entity.state;
            return department;
        }
    }
}
