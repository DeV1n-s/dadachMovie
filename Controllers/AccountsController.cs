using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Helpers;
using Gridify;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

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
        
        [HttpPost("Create")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo userInfo)
        {
            var userToken = await _accountsService.CreateUserAsync(userInfo);
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserToken>> Renew()
        {
            var userInfo = new UserInfo
            {
                EmailAddress = HttpContext.User.Identity.Name
            };

            return await _accountsService.RenewUserBearerTokenAsync(userInfo);
        }

        [HttpGet("Users")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<Paging<UserDTO>>> Get([FromQuery] GridifyQuery gridifyQuery) =>
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