using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using API.Helpers;
using API.Services;
using Application.Roles.UserRoles;
using Domain;
using Domain.PMPA.Model;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseApiController
    //ControllerBase
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


        [AllowAnonymous]
        [HttpPost("SendPasswordEmail")]
           public async Task<ActionResult<bool>> SendResetLink(PasswordRequestDto requestObj)
           {
               if (string.IsNullOrEmpty(requestObj.Email))
                {
                    return BadRequest("Invalid email.");
                }

            return await RequestPasswordReset(requestObj.Email, requestObj.Url);

            //return Ok();
            //return true;
            }


          private async Task<bool> RequestPasswordReset(string email, string url)
           {
               var user = await _userManager.FindByEmailAsync(email);

                if (user!=null)
               {
                return await RequestPasswordResetLink(user, url);
                   
                }
            return false;

                //logger.LogWarning("Reset password requested for an account that did not exist.");
            }

          private async Task<bool> RequestPasswordResetLink(AppUser user, string url)
         {

            try
            {

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);



                var sendMailStatus = await EmailSender.SendEmailAsync(user, code, url);


                var acctRecoveryDetailOpResult = false;

                if (sendMailStatus)
                {
                    //create a userReset record and store reset token , createdDate
                    var userAcctRecoveryDetail = new UserAcctRecoveryDetail
                    {
                        Id = Guid.NewGuid(),
                        RecoveryToken = HttpUtility.UrlEncode(code),
                        UserId = user.Id,
                        Status = UserAcctRecoveryStatus.Initiated,
                        RequestCreateDate = DateTime.UtcNow,
                        OldPassword = user.PasswordHash

                    };

                    acctRecoveryDetailOpResult =   (await Mediator.Send(new Application.UserAcctRecoveryDetail.Create.Command { UserAcctRecoveryDetail = userAcctRecoveryDetail })).IsSuccess;
                }

                return sendMailStatus && acctRecoveryDetailOpResult;

                //logger.LogInformation($"An password reset email was sent to {user.Email}");
            }
            catch (Exception ex)
            {
                throw;
            }
            
          }



        [AllowAnonymous]
        [HttpPost("ChangePassword")]
public async Task<IActionResult> ChangePassword(UserAcctRecoveryDetail requestObj)
        {
            var token = requestObj.RecoveryToken;
            var userAcctRecoveryDetail = await Mediator.Send(new Application.UserAcctRecoveryDetail.Details.Query { Token = token });
            if (!userAcctRecoveryDetail.IsSuccess) return NotFound("Invalid request");

            var user = await _signInManager.UserManager.FindByIdAsync(userAcctRecoveryDetail.Value.UserId);
            if(user==null) return NotFound("Invalid request");

            var opResult = await _signInManager.UserManager.ResetPasswordAsync(user, token, requestObj.NewPassword);
            if (opResult.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(409, opResult.Errors);
            }

        }






        //[HttpPost("ResetPassword")]

        //public async Task<IActionResult> ResetPassword([FromBody] ChangePasswordViewModel model)
        //{
        //    var result = await ResetPassword(model);

        //    if (!result)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while resetting your password. Please try again later."


        //            );
        //    }

        //    return Ok();
        //}

        //public async Task<bool> ResetPassword(ChangePasswordViewModel model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);

        //    if (!user.IsEmpty())
        //    {
        //        var result = await _userManager.ResetPasswordAsync(user, model.ResetPasswordToken.FromBase64(), model.Password);

        //        if (result.Succeeded)
        //        {
        //            var emailContent = $"Your password is reset now";

        //            await emailSender.SendEmailAsync(user.Email, "Password Reset Complete", emailContent);

        //            return true;
        //        }
        //    }
        //    return false;
        //}












        [HttpPost("AddUser")]
        public async Task<ActionResult<UserDto>> AddUser(RegisteredUserDto registeredUserDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registeredUserDto.Email))
            {
                ModelState.AddModelError("email", "email taken");
                return ValidationProblem();
            }

            var user = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                ClientId = registeredUserDto.ClientId,
                FirstName = registeredUserDto.FirstName,
                LastName = registeredUserDto.LastName,
                Email = registeredUserDto.Email,
                UserName = registeredUserDto.Email,
                Address1 = registeredUserDto.Address,
                City = registeredUserDto.City,
                State = registeredUserDto.State,
                Zip = registeredUserDto.ZipCode,
                Country = registeredUserDto.Country,
                Phone = registeredUserDto.PhoneNumber,
               // SysTimeZone = registeredUserDto.SysTimeZone,
               // SysTimeOffset = registeredUserDto.SysTimeOffset,
                CreatedBy = registeredUserDto.ClientSideChangeBy,
                CreateDateTime = DateTime.UtcNow,

            };

            var result = await _userManager.CreateAsync(user, registeredUserDto.Password);
            if (result.Succeeded)
            {
                //send a command to create the user photo

                return new UserDto
                {
                    UserId = user.Id,
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
        public async Task<ActionResult<bool>> EditUser(string id, RegisteredUserDto registeredUserDto)
        {
            var user = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                UpdateUserObject(ref user, registeredUserDto);

                //update user
                var result = await _userManager.UpdateAsync(user);

               
                //delete roles
                var deleteResult = await Mediator.Send(new DeleteAllUserRolesByUserId.Command { UserId = registeredUserDto.UserId });



                //create role
                var roles = CreateRoleObject(registeredUserDto.Roles);
                var createResult = await Mediator.Send(new Create.Command { UserId = registeredUserDto.UserId, Roles = roles });
                

                if (result.Succeeded && createResult.IsSuccess)
                {
                    //send a command to update user photo

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



        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(string id)
        {
            var opResult = false;

            var user = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                opResult = true;
            }
            //send a command to delete the user photo

            return opResult;
            //HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<RegisteredUserDto>>> GetAllActiveUsers()
        {
            var users = await _userManager.Users.Include(x=>x.UserPhoto).Include(x => x.UserRoles).ThenInclude(x => x.Role).ToListAsync();

            return CreateRegisterObject(users);
        }

        [HttpGet("GetRegisteredUser/{id}")]
        public async Task<ActionResult<RegisteredUserDto>> GetRegisteredUser(string id)
        {
            var user = await _userManager.Users.Include(x => x.UserPhoto).Include(x => x.UserRoles).ThenInclude(x => x.Role).Where(x => x.Id == id).ToListAsync();
            return CreateRegisterObject(user).First();
        }


        private void UpdateUserObject(ref AppUser user, RegisteredUserDto registerDto)
        {
            user.Active = registerDto.Active;
            user.Address1 = registerDto.Address;
            user.City = registerDto.City;
            user.Country = registerDto.Country;
            user.Email = registerDto.Email;
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.IsAdmin = registerDto.IsAdmin != null ? registerDto.IsAdmin.Value : false;
            user.LastUpdateDateTime = DateTime.UtcNow;
            user.LastUpdatedBy = registerDto.ClientSideChangeBy;
            user.Phone = registerDto.PhoneNumber;
            //user.ProfileImage = registerDto.ProfileImage;
            //user.ProfilePath = registerDto.ProfilePath;
            //user.SysTimeZone = registerDto.SysTimeZone;
            //user.SysTimeOffset = registerDto.SysTimeOffset;

        }

        private UserDto CreateUserObject(AppUser user)
        {
            return new UserDto
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ClientId = user.ClientId.Value,
                Token = _tokenService.CreateToken(user),
                Image = null

            };
        }

        private List<RegisteredUserDto> CreateRegisterObject(List<AppUser> users)
        {

            var result = new List<RegisteredUserDto>();
            foreach (var user in users)
            {
                result.Add(
                    new RegisteredUserDto
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
                        ImageId = user.UserPhoto?.Id,
                        ImagePath = user.UserPhoto?.Url,
                        //SysTimeZone = user.SysTimeZone,
                        //SysTimeOffset = user.SysTimeOffset,

                        UserId = user.Id,
                        ClientId = user.ClientId.Value,
                        Roles = CreateRoleDtoObject(user.UserRoles)



                    }
                );
            }


            return result;
        }

        private List<RoleDto> CreateRoleDtoObject(ICollection<UserRole> userRoles)
        {

            var roleDtos = new List<RoleDto>();
            foreach (var userRole in userRoles)
            {
                roleDtos.Add(new RoleDto
                {
                    RoleId = userRole.RoleId,
                    RoleName = userRole.Role.RoleName,
                    Active = userRole.Role.Active,
                    ProjectId = userRole.Role.ProjectId,
                    CreatedBy = userRole.Role.CreatedBy,
                    CreatedDate = userRole.Role.CreatedDate,
                    LastUpdatedBy = userRole.Role.LastUpdatedBy,
                    LastUpdatedDate = userRole.Role.LastUpdatedDate
                });
            }

            return roleDtos;
        }

        private List<Role> CreateRoleObject(ICollection<RoleDto> roleDtos)
        {
            var roles = new List<Role>();
            foreach (var roleDto in roleDtos)
            {
                roles.Add(new Role
                {

                     RoleId = roleDto.RoleId,
       RoleName = roleDto.RoleName,
        Active = roleDto.Active,
        CreatedBy =roleDto.CreatedBy,
         CreatedDate =roleDto.CreatedDate,
        LastUpdatedBy =roleDto.LastUpdatedBy,
       LastUpdatedDate = roleDto.LastUpdatedDate,

        ProjectId=roleDto.ProjectId

                });
            }

            return roles;
        }
    }
}