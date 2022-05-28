using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.ClientProjects;
using Domain;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{


    public class ClientProjectController : BaseApiController
    {

        [HttpGet("GetAllClientProjects")]
        public async Task<IActionResult> GetAllClientProjects(CancellationToken ct)
        {
            return HandleResult(await Mediator.Send(new List.Query(), ct));
        }

        [HttpGet("GetClientProjectsByClientId/{id}")]
        public async Task<IActionResult> GetClientProjectsByClientId(Guid id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id , SearchBy = SearchByEnums.ByKey});
             return HandleResult(result);
        }

        [HttpGet("GetClientProjectByProjectId/{id}")]
        public async Task<IActionResult> GetClientProjectByProjectId(Guid id)
        {
            var val = await Mediator.Send(new Details.Query { Id = id, SearchBy = SearchByEnums.ByProjectId });
         var result = val.Value.FirstOrDefault();
          return HandleResult(Result<ClientProject>.Success(result));

        }

        [HttpPost]
        public async Task<IActionResult> CreateClientProject(ClientProject clientProject)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ClientProject = clientProject }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClientProject(Guid id, ClientProject clientProject)
        {
            clientProject.ProjectId = id;
            return HandleResult(await Mediator.Send(new Edit.Command { ClientProject = clientProject }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProject(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}