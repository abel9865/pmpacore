using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
[ApiController]
    [Route("[controller]")]
    public class ClientProjectController : ControllerBase
    {
        private readonly DataContext _context;
        public ClientProjectController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("GetAllClientProjects")]
        public async Task<ActionResult<List<ClientProject>>> GetAllClientProjects()
        {
            return await _context.ClientProject.ToListAsync();
        }
        [HttpGet("GetClientProjects")]
        public async Task<ActionResult<List<ClientProject>>> GetClientProjects(Guid clientId)
        {
            return await _context.ClientProject.Where(x=>x.ClientId==clientId).ToListAsync();
        }
    }
}