using Business.Parameter.Interfaces;
using Entity.Dto.Parameter;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Parameter.Interfaces;

namespace Web.Controllers.Parameter.Implementations
{
    [ApiController]
    [Route("[controller]")]
    public class ContinentControllers : ControllerBase, IContinentControllers
    {
        private readonly IContinentBusiness _ContinentBusiness;
        public ContinentControllers(IContinentBusiness ContinentBusiness)
        {
            _ContinentBusiness = ContinentBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Continent>>> SelectAll()
        {
            var result = await _ContinentBusiness.SelectAll();
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ContinentDto>> GetById(int id)
        {
            var result = await _ContinentBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _ContinentBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ContinentDto>> Save([FromBody] ContinentDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _ContinentBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new {id = result.Id }, result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContinentDto entity)
        {
            if(entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _ContinentBusiness.Update(id, entity);
            return NoContent();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ContinentBusiness.Delete(id);
            return NoContent();
        }
    }
}
