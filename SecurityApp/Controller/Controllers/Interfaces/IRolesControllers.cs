﻿using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers.Interfaces
{
    public interface IRolesControllers
    {

        Task<ActionResult<IEnumerable<RolesDto>>> SelectAll();
        Task<ActionResult<RolesDto>> GetById(int id);
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<RolesDto>> Save([FromBody] RolesDto entity);
        Task<IActionResult> Update(int id, RolesDto entity);
        Task<IActionResult> Delete(int id);
    }
}
