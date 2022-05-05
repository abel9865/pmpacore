using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Services;
using Domain;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager,

        SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                // return new UserDto
                // {
                //     FirstName = user.FirstName,
                //     LastName = user.LastName,
                //     Email = user.Email,
                //     ClientId = user.ClientId.Value,
                //     Token = _tokenService.CreateToken(user),
                //     Image = null

                // };

                 return CreateUserObject(user);
            }

            return Unauthorized();
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<UserDto>> AddUser(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email taken");
            }

            var user = new AppUser
            {
                UserId = Guid.NewGuid(),
                ClientId = registerDto.ClientId,
                FirstName = registerDto.FirtName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Address1 = registerDto.Address,
                City = registerDto.City,
                State = registerDto.State,
                Zip = registerDto.ZipCode,
                Country = registerDto.Country,
                SysTimeZone = registerDto.SysTimeZone,
                SysTimeOffset = registerDto.SysTimeOffset,
                CreatedBy = registerDto.AdminUserId,
                CreateDateTime = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                return new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
            }
            return BadRequest("Problem adding user");

        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser(){
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            return CreateUserObject(user);

        }

        private UserDto CreateUserObject(AppUser user){
             return new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    ClientId = user.ClientId.Value,
                    Token = _tokenService.CreateToken(user),
                    Image = null

                };
        }
    }
}