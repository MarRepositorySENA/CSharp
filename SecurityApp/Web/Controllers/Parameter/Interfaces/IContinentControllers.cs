using Entity.Dto.Parameter;
using Entity.Model.Dto;
using Entity.Model.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Parameter.Interfaces
{
    public interface IContinentControllers
    {
        Task<ActionResult<IEnumerable<Continent>>> SelectAll();
        Task<ActionResult<ContinentDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<ContinentDto>> Save([FromBody] ContinentDto entity);
        Task<IActionResult> Update(int id, ContinentDto entity);
        Task<IActionResult> Delete(int id);
    }
}
