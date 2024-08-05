using Business.Security.Implementations;
using Business.Security.Interfaces;
using Controller.Controllers.Interfaces;
using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers.Implementations
{
    [ApiController]
    [Route("[controller]")]
    public class Users_RolesControllers : ControllerBase, IUsers_RolesControllers
    {
        private readonly IUsers_RolesBusiness _User_RoleBusiness;

        public Users_RolesControllers(IUsers_RolesBusiness Users_RolesBusiness)
        {
            _User_RoleBusiness = Users_RolesBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users_RolesDto>>> SelectAll()
        {
            var result = await _User_RoleBusiness.SelectAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users_RolesDto>> GetById(int id)
        {
            var result = await _User_RoleBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _User_RoleBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Users_RolesDto>> Save([FromBody] Users_RolesDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _User_RoleBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Users_RolesDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _User_RoleBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _User_RoleBusiness.Delete(id);
            return NoContent();
        }

    }
}
