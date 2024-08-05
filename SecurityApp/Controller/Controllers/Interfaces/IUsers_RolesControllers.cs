using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers.Interfaces
{
    public interface IUsers_RolesControllers
    {
        Task<ActionResult<IEnumerable<Users_RolesDto>>> SelectAll();
        Task<ActionResult<Users_RolesDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<Users_RolesDto>> Save([FromBody] Users_RolesDto entity);
        Task<IActionResult> Update(int id, Users_RolesDto entity);
        Task<IActionResult> Delete(int id);
    }
}
