using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers.Interfaces
{
    public interface IModulesControllers
    {

        Task<ActionResult<IEnumerable<ModulesDto>>> SelectAll();
        Task<ActionResult<ModulesDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<ModulesDto>> Save([FromBody] ModulesDto entity);
        Task<IActionResult> Update(int id, ModulesDto entity);
        Task<IActionResult> Delete(int id);
    }
}
