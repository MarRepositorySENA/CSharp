using Entity.Dto.Parameter;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Interfaces
{
    public interface ICityControllers
    {


        Task<ActionResult<IEnumerable<City>>> SelectAll();
        Task<ActionResult<CityDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<CityDto>> Save([FromBody] CityDto entity);
        Task<IActionResult> Update(int id, CityDto entity);
        Task<IActionResult> Delete(int id);


       
    }
}
