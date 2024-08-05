using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers.Interfaces
{
    public interface IRoles_ViewsControllers
    {

        Task<ActionResult<IEnumerable<Roles_ViewsDto>>> SelectAll();
        Task<ActionResult<Roles_ViewsDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<Roles_ViewsDto>> Save([FromBody] Roles_ViewsDto entity);
        Task<IActionResult> Update(int id, Roles_ViewsDto entity);
        Task<IActionResult> Delete(int id);

    }
}
