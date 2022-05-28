using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
   
    public class RoleController : BaseApiController
    {
      
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles(CancellationToken ct)
        {
            return HandleResult(await Mediator.Send(new Application.Roles.List.Query(), ct));
        }

        [HttpGet("GetRolesByRoleId/{id}")]
        public async Task<IActionResult> GetRolesByRoleId(Guid id)
        {
            var result = await Mediator.Send(new Application.Roles.Details.Query { Id = id, SearchBy = SearchByEnums.ByKey});
             return HandleResult(result);
        }


        [HttpGet("GetRolesByProjectId/{id}")]
        public async Task<IActionResult> GetRolesByProjectId(Guid id)
        {
            var result = await Mediator.Send(new Application.Roles.Details.Query { Id = id, SearchBy = SearchByEnums.ByProjectId});
             return HandleResult(result);
        }

           [HttpGet("GetRolesByClientId/{id}")]
        public async Task<IActionResult> GetRolesByClientId(Guid id)
        {
            var result = await Mediator.Send(new Application.Roles.Details.Query { Id = id, SearchBy = SearchByEnums.ByClientId});
             return HandleResult(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(Role role)
        {
            return HandleResult(await Mediator.Send(new Application.Roles.Create.Command { Role = role }));
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> EditRole(Guid id, Role role)
        {
            role.RoleId = id;
            return HandleResult(await Mediator.Send(new Application.Roles.Edit.Command { Role = role }));
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            return HandleResult(await Mediator.Send(new Application.Roles.Delete.Command { Id = id }));
        }
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}