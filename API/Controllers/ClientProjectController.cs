using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ClientProjects;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ClientProjectController : BaseApiController
    {

        [HttpGet("GetAllClientProjects")]
        public async Task<ActionResult<List<ClientProject>>> GetAllClientProjects(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query(), ct);
        }
        [HttpGet("GetClientProjects")]
        public async Task<ActionResult<List<ClientProject>>> GetClientProjects(Guid clientId)
        {
            return await Mediator.Send(new Details.Query{Id = clientId});
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateClientProject(ClientProject clientProject){
            return Ok(await Mediator.Send(new Create.Command{ClientProject= clientProject}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClientProject(Guid id, ClientProject clientProject)
        {
           clientProject.ProjectId = id;
           return Ok(await Mediator.Send(new Edit.Command{ClientProject = clientProject}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProject(Guid id){
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}