using Business.Security.Interfaces;
using Controller.Controllers.Interfaces;
using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers.Implementations
{

    [ApiController]
    [Route("[controller]")]
    public class Roles_ViewsControllers : ControllerBase, IRoles_ViewsControllers
    {
        private readonly IRoles_ViewsBusiness _Roles_ViewsBusiness;

        public Roles_ViewsControllers(IRoles_ViewsBusiness Roles_ViewsBusiness)
        {
            _Roles_ViewsBusiness = Roles_ViewsBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles_ViewsDto>>> SelectAll()
        {
            var result = await _Roles_ViewsBusiness.SelectAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Roles_ViewsDto>> GetById(int id)
        {
            var result = await _Roles_ViewsBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _Roles_ViewsBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Roles_ViewsDto>> Save([FromBody] Roles_ViewsDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _Roles_ViewsBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Roles_ViewsDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _Roles_ViewsBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _Roles_ViewsBusiness.Delete(id);
            return NoContent();
        }


    }
}
