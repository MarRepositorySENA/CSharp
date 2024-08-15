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
    public class CountryControllers : ControllerBase, ICountryControllers
    {
        private readonly ICountryBusiness _CountryBusiness;
        public CountryControllers (ICountryBusiness CountryBusiness)
        {
            _CountryBusiness = CountryBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> SelectAll()
        {
            var result = await _CountryBusiness.SelectAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            var result = await _CountryBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var rsult = await _CountryBusiness.GetAllSelect();
            return Ok(rsult);   
        }

        [HttpPost]
        public async Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _CountryBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new {id = result.Id}, result);
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CountryDto entity)
        {
            if(entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _CountryBusiness.Update(id, entity);
            return NoContent();
               
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _CountryBusiness.Delete(id);
            return NoContent();
        }
    }
}
