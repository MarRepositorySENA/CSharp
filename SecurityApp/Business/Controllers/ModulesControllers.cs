using Microsoft.AspNetCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Entity.Model.Dto;
using Entity.Model.Security;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace Business.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModulesBusiness business;

        public ModulesController(IModulesBusiness business)
        {
            this.business = business;
        }

        [HttpGet("datatable")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ModulesDto>>>> Get([FromQuery] QueryFilterDto filters)
        {
            // Implementar la lógica para filtrar y retornar los datos
            // Por ahora retornamos un ejemplo
            var response = new ApiResponse<IEnumerable<ModulesDto>>
            {
                Success = true,
                Data = new List<ModulesDto>() // Reemplazar con datos reales
            };
            return Ok(response);
        }

        [HttpGet("AllSelect")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect()
        {
            var dataSelect = await this.business.GetAllSelect();
            var response = new ApiResponse<IEnumerable<DataSelectDto>>
            {
                Success = true,
                Data = dataSelect
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ModulesDto>>> Get(int id)
        {
            try
            {
                var person = await this.business.GetById(id);
                if (person == null)
                {
                    return NotFound(new ApiResponse<ModulesDto> { Success = false, Message = "person not found" });
                }
                var response = new ApiResponse<ModulesDto>
                {
                    Success = true,
                    Data = person
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<ModulesDto> { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ModulesDto>>> Post([FromBody] ModulesDto Modules)
        {
            try
            {
                var createdPerson = await this.business.Save(Modules);
                var response = new ApiResponse<ModulesDto>
                {
                    Success = true,
                    Data = createdPerson
                };
                return CreatedAtAction(nameof(Get), new { id = createdPerson.Id }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<ModulesDto> { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ModulesDto>>> Put(int id, [FromBody] ModulesDto Modules)
        {
            try
            {
                await this.business.Update(id, Modules);
                var response = new ApiResponse<ModulesDto>
                {
                    Success = true,
                    Message = "Person updated successfully"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<ModulesDto> { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<ModulesDto>>> Delete(int id)
        {
            try
            {
                await this.business.Delete(id);
                var response = new ApiResponse<ModulesDto>
                {
                    Success = true,
                    Message = "Person deleted successfully"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<ModulesDto> { Success = false, Message = ex.Message });
            }
        }
    }
}
