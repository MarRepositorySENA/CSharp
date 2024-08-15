using Entity.Dto.Parameter;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Interfaces
{
    public interface ICountryControllers
    {
        Task<ActionResult<IEnumerable<Country>>> SelectAll();
        Task<ActionResult<CountryDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity);
        Task<IActionResult> Update(int id, CountryDto entity);
        Task<IActionResult> Delete(int id);
    }
}
