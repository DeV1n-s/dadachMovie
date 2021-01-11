using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
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
            var userToken = await _accountsService.RegisterUserAsync(userCreationDTO);
            if (userToken == null)
                return BadRequest();

            return userToken;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var userToken = await _accountsService.UserLoginAsync(userInfo);
            if (userToken == null)
                return BadRequest("Invalid login attempt");
            
            return userToken;
        }

        [HttpPut("UpdateUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateUser([FromForm] UserUpdateDTO userUpdateDTO)
        {
            if(!await _accountsService.UpdateUserAsync(userUpdateDTO))
                return NotFound();
                
            return NoContent();
        }

        [HttpPost("RenewToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserToken>> RenewToken()
        {
            var userInfo = new UserInfo
            {
                EmailAddress = HttpContext.User.Identity.Name
            };

            return await _accountsService.RenewUserBearerTokenAsync(userInfo.EmailAddress);
        }

        [HttpGet("Users")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<Paging<UserDTO>>> GetUsers([FromQuery] GridifyQuery gridifyQuery) =>
            await _accountsService.GetUsersPagingAsync(gridifyQuery);

        [HttpGet("Roles")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<List<string>>> GetRoles() =>
            await _accountsService.GetRolesListAsync();

        [HttpPost("AssignRole")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> AssignRole(EditRoleDTO editRoleDTO)
        {
            if (!await _accountsService.AssignUserRoleAsync(editRoleDTO))
                return NotFound();

            return NoContent();
        }

        [HttpPost("RemoveRole")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> RemoveRole(EditRoleDTO editRoleDTO)
        {
            if (!await _accountsService.RemoveUserRoleAsync(editRoleDTO))
                return NotFound();

            return NoContent();
        }
    }
}