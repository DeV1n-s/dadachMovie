using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Validations;
using Gridify;
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
        [ValidateModelAttribute]
        public async Task<ActionResult<UserToken>> Register([FromBody] UserCreationDTO userCreationDTO)
        {
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
        [ValidateModelAttribute]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var userLogin = await _accountsService.UserLoginAsync(userInfo);
            if (!userLogin.Succeeded)
                return BadRequest("Invalid login attempt");
            
            return await _accountsService.BuildToken(userInfo.EmailAddress);
        }

        [HttpPut("UpdateUser")]
        [Authorize]
        [ValidateModelAttribute]
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
            var userEmail = _accountsService.GetCurrentUserEmail();
            return await _accountsService.RenewUserBearerTokenAsync(userEmail);
        }

        [HttpGet("Users")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Paging<UserDTO>>> GetUsers([FromQuery] GridifyQuery gridifyQuery) =>
            await _accountsService.GetUsersPagingAsync(gridifyQuery);

        [HttpGet("CurrentUser")]
        [Authorize]
        public async Task<ActionResult<UserDetailsDTO>> GetCurrentUser() =>
            await _accountsService.GetCurrentUserDetailsAsync();

        [HttpGet("Roles")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<string>>> GetRoles() =>
            await _accountsService.GetRolesListAsync();

        [HttpPost("AssignRole")]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
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
        [ValidateModelAttribute]
        public async Task<ActionResult> RemoveRole(EditRoleDTO editRoleDTO)
        {
            var result = await _accountsService.RemoveUserRoleAsync(editRoleDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpPost("SaveUserRating")]
        [ValidateModelAttribute]
        [Authorize]
        public async Task<ActionResult> SaveUserRating([FromBody] MovieRatingDTO movieRatingDTO)
        {
            var result = await _accountsService.SaveUserRatingAsync(movieRatingDTO);
            if (result == -1)
                return BadRequest(ModelState);
            
            return NoContent();
        }

        [HttpPost("SaveUserFavoriteMovies")]
        [ValidateModelAttribute]
        [Authorize]
        public async Task<ActionResult> SaveUserFavoriteMovies([FromBody] UserFavoriteMoviesDTO userFavoriteMoviesDTO)
        {
            var result = await _accountsService.SaveUserFavoriteMoviesAsync(userFavoriteMoviesDTO);

            if (result == -2) {
                ModelState.TryAddModelError("movieId", $"Movie with ID {userFavoriteMoviesDTO.MovieId} was not found.");
                return NotFound(ModelState);

            } else if(result == -3) {
                ModelState.TryAddModelError("userId", $"User with ID {userFavoriteMoviesDTO.UserId} was not found.");
                return NotFound(ModelState);

            } else if (result == -1) {
                ModelState.TryAddModelError("saveChangesAsync", "Failed to save changes async.");
                return NotFound(ModelState);
                
            } else {
                return NoContent();
            }
            
        }
    }
}