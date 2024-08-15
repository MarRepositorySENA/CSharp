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
    public class CityControllers : ControllerBase, ICityControllers
    {
        private readonly ICityBusiness _CityBusiness;
        public CityControllers(ICityBusiness CityBusiness)
        {
            _CityBusiness = CityBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> SelectAll()
        {
            var result = await _CityBusiness.SelectAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetById(int id)
        {
            var result = await _CityBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _CityBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> Save([FromBody] CityDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _CityBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById),new {id = result.Id}, result);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CityDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest(); 
            }
            await _CityBusiness.Update(id, entity);
            return NoContent(); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _CityBusiness.Delete(id);
            return NoContent();
        }

        
        

        
        
    }
}
