using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Validations;
using Gridify;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }
        
        [HttpPost("Register")]
        public async Task<ActionResult<UserToken>> Register([FromBody] UserCreationDTO userCreationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value.Errors)
                                            .Where(x => x.Count > 0)
                                            .ToList());
            }

            var userRegister = await _accountsService.RegisterUserAsync(userCreationDTO);
            if (!userRegister.Succeeded)
            {
                foreach (var error in userRegister.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return await _accountsService.BuildToken(userCreationDTO.EmailAddress);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var userLogin = await _accountsService.UserLoginAsync(userInfo);
            if (!userLogin.Succeeded)
                return BadRequest("Invalid login attempt");
            
            return await _accountsService.BuildToken(userInfo.EmailAddress);
        }

        [HttpPut("UpdateUser")]
        [Authorize]
        public async Task<ActionResult> UpdateUser([FromForm] UserUpdateDTO userUpdateDTO)
        {
            var result = await _accountsService.UpdateUserAsync(userUpdateDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpPost("RenewToken")]
        [Authorize]
        public async Task<ActionResult<UserToken>> RenewToken()
        {
            var userInfo = new UserInfo
            {
                EmailAddress = HttpContext.User.Identity.Name
            };

            return await _accountsService.RenewUserBearerTokenAsync(userInfo.EmailAddress);
        }

        [HttpGet("Users")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Paging<UserDTO>>> GetUsers([FromQuery] GridifyQuery gridifyQuery) =>
            await _accountsService.GetUsersPagingAsync(gridifyQuery);

        [HttpGet("CurrentUser")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetCurrentUser() =>
            await _accountsService.GetCurrentUserAsync();

        [HttpGet("Roles")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<string>>> GetRoles() =>
            await _accountsService.GetRolesListAsync();

        [HttpPost("AssignRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AssignRole(EditRoleDTO editRoleDTO)
        {
            var result = await _accountsService.AssignUserRoleAsync(editRoleDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpPost("RemoveRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveRole(EditRoleDTO editRoleDTO)
        {
            var result = await _accountsService.RemoveUserRoleAsync(editRoleDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        // [HttpPost("CheckEmailAvailability")]
        // [Authorize(Roles = "Admin")]
        // public async Task<ActionResult> CheckEmailAvailability(string emailAddress)
        // {
        //     var exists = await _accountsService.GetUserByEmailAsync(emailAddress);
        //     if (exists == null)
        //         return NotFound("User doesn't exists.");

        //     return Ok("Another user is already registered with this email address.");
        // }
    }
}