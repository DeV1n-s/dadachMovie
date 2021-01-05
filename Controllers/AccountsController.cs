using System.Collections.Generic;
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
        public async Task<ActionResult<UserToken>> Register([FromBody] UserInfo userInfo)
        {
            var userToken = await _accountsService.RegisterUserAsync(userInfo);
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

        [HttpPost("RenewToken")]
        [Authorize]
        public async Task<ActionResult<UserToken>> RenewToken()
        {
            var userInfo = new UserInfo
            {
                EmailAddress = HttpContext.User.Identity.Name
            };

            return await _accountsService.RenewUserBearerTokenAsync(userInfo);
        }

        [HttpGet("Users")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Paging<UserDTO>>> GetUsers([FromQuery] GridifyQuery gridifyQuery) =>
            await _accountsService.GetUsersPagingAsync(gridifyQuery);

        [HttpGet("Roles")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<string>>> GetRoles() =>
            await _accountsService.GetRolesListAsync();

        [HttpPost("AssignRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AssignRole(EditRoleDTO editRoleDTO)
        {
            if (!await _accountsService.AssignUserRoleAsync(editRoleDTO))
                return NotFound();

            return NoContent();
        }

        [HttpPost("RemoveRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveRole(EditRoleDTO editRoleDTO)
        {
            if (!await _accountsService.RemoveUserRoleAsync(editRoleDTO))
                return NotFound();

            return NoContent();
        }
    }
}