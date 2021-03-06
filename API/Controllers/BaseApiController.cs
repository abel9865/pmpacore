using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        private IUserAccessor _userAccessor;

        protected IMediator Mediator => _mediator??=HttpContext.RequestServices.GetService<IMediator>();
        protected IUserAccessor UserAccessor => _userAccessor ??= HttpContext.RequestServices.GetService<IUserAccessor>();


        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if(result==null) return NotFound();
            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
            }
            if (result.IsSuccess && result.Value == null)
            {
                return NotFound();
            }
            return BadRequest(result.Error);
        }
        
    }
}