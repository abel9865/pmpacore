using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Helpers;
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
                ModelState.AddModelError("email", "email taken");
                return ValidationProblem();
            }

            var user = new AppUser
            {
                UserId = Guid.NewGuid(),
                ClientId = registerDto.ClientId,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                Address1 = registerDto.Address,
                City = registerDto.City,
                State = registerDto.State,
                Zip = registerDto.ZipCode,
                Country = registerDto.Country,
                Phone = registerDto.PhoneNumber,
                SysTimeZone = registerDto.SysTimeZone,
                SysTimeOffset = registerDto.SysTimeOffset,
                CreatedBy = registerDto.ClientSideChangeBy,
                CreateDateTime = DateTime.UtcNow,

            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                return new UserDto
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
            }
            var flattenErrors = UtilHelpers.FlattenErrors(result.Errors, " - ");
            ModelState.AddModelError("addUser", $"Problem adding user :  {flattenErrors} ");
            return ValidationProblem();

        }

        [HttpPut("EditUser/{id}")]
        public async Task<ActionResult<bool>> EditUser(Guid id, RegisterDto registerDto)
        {
            var user = await _userManager.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (user != null)
            {
                UpdateUserObject(ref user, registerDto);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }
                var flattenErrors = UtilHelpers.FlattenErrors(result.Errors, " - ");
                ModelState.AddModelError("updateUser", $"Problem updating user :  {flattenErrors} ");
                return ValidationProblem();
            }
            else
            {
                ModelState.AddModelError("userUpdate", "cannot update user account");
                return ValidationProblem();
            }


        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            return CreateUserObject(user);

        }


        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<RegisterDto>>> GetAllActiveUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return CreateRegisterObject(users);
        }

        [HttpGet("GetRegisteredUser/{id}")]
        public async Task<ActionResult<RegisterDto>> GetRegisteredUser(Guid id)
        {
            var user = await _userManager.Users.Where(x => x.UserId == id).ToListAsync();
            return CreateRegisterObject(user).First();
        }


        private void UpdateUserObject(ref AppUser user, RegisterDto registerDto)
        {
            user.Active = registerDto.Active;
            user.Address1 = registerDto.Address;
            user.City = registerDto.City;
            user.Country = registerDto.Country;
            user.Email = registerDto.Email;
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.IsAdmin = registerDto.IsAdmin!=null? registerDto.IsAdmin.Value: false;
            user.LastUpdateDateTime = DateTime.UtcNow;
            user.LastUpdatedBy = registerDto.ClientSideChangeBy;
            user.Phone = registerDto.PhoneNumber;
            user.ProfileImage = registerDto.ProfileImage;
            user.ProfilePath = registerDto.ProfilePath;
            user.SysTimeZone = registerDto.SysTimeZone;
            user.SysTimeOffset = registerDto.SysTimeOffset;

        }

        private UserDto CreateUserObject(AppUser user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ClientId = user.ClientId.Value,
                Token = _tokenService.CreateToken(user),
                Image = null

            };
        }

        private List<RegisterDto> CreateRegisterObject(List<AppUser> users)
        {

            var result = new List<RegisterDto>();
            foreach (var user in users)
            {
                result.Add(
                    new RegisterDto
                    {


                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.Phone,
                        Address = user.Address1,
                        City = user.City,
                        State = user.State,
                        ZipCode = user.Zip,
                        Country = user.Country,
                        IsAdmin = user.IsAdmin,

                        Active = user.Active,
                        ProfileImage = user.ProfileImage,
                        ProfilePath = user.ProfilePath,
                        SysTimeZone = user.SysTimeZone,
                        SysTimeOffset = user.SysTimeOffset,

                        UserId = user.UserId,
                        ClientId = user.ClientId.Value

                    }
                );
            }


            return result;
        }
    }
}