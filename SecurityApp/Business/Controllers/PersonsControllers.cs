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
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsBusiness business;

        public PersonsController(IPersonsBusiness business)
        {
            this.business = business;
        }

        [HttpGet("datatable")]
        public async Task<ActionResult<ApiResponse<IEnumerable<PersonsDto>>>> Get([FromQuery] QueryFilterDto filters)
        {
            // Implementar la lógica para filtrar y retornar los datos
            // Por ahora retornamos un ejemplo
            var response = new ApiResponse<IEnumerable<PersonsDto>>
            {
                Success = true,
                Data = new List<PersonsDto>() // Reemplazar con datos reales
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
        public async Task<ActionResult<ApiResponse<PersonsDto>>> Get(int id)
        {
            try
            {
                var person = await this.business.GetById(id);
                if (person == null)
                {
                    return NotFound(new ApiResponse<PersonsDto> { Success = false, Message = "person not found" });
                }
                var response = new ApiResponse<PersonsDto>
                {
                    Success = true,
                    Data = person
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<PersonsDto> { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
         public async Task<ActionResult<ApiResponse<PersonsDto>>> Post([FromBody] PersonsDto Persons)
         {
             try
             {
                 var createdPerson = await this.business.Save(Persons);
                 var response = new ApiResponse<PersonsDto>
                 {
                     Success = true,
                     Data = createdPerson
                 };
                 return CreatedAtAction(nameof(Get), new { id = createdPerson.Id }, response);
             }
             catch (Exception ex)
             {
                 return StatusCode(500, new ApiResponse<PersonsDto> { Success = false, Message = ex.Message });
             }
         }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<PersonsDto>>> Put(int id, [FromBody] PersonsDto Persons)
        {
            try
            {
                await this.business.Update(id, Persons);
                var response = new ApiResponse<PersonsDto>
                {
                    Success = true,
                    Message = "Person updated successfully"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<PersonsDto> { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<PersonsDto>>> Delete(int id)
        {
            try
            {
                await this.business.Delete(id);
                var response = new ApiResponse<PersonsDto>
                {
                    Success = true,
                    Message = "Person deleted successfully"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<PersonsDto> { Success = false, Message = ex.Message });
            }
        }
    }
}
