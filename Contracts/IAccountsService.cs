using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using Gridify;
using Microsoft.AspNetCore.Identity;

namespace dadachMovie.Contracts
{
    public interface IAccountsService
    {
        Task<Paging<UserDTO>> GetUsersPagingAsync(GridifyQuery gridifyQuery);
        Task<UserDetailsDTO> GetCurrentUserDetailsAsync();
        string GetCurrentUserEmail();
        Task<List<string>> GetRolesListAsync();
        Task<int> AssignUserRoleAsync(EditRoleDTO editRoleDTO);
        Task<int> RemoveUserRoleAsync(EditRoleDTO editRoleDTO);
        Task<IdentityResult> RegisterUserAsync(UserCreationDTO userCreationDTO);
        Task<SignInResult> UserLoginAsync(UserInfo userInfo);
        Task<int> UpdateUserAsync(UserUpdateDTO userUpdateDTO);
        Task<UserToken> RenewUserBearerTokenAsync(string emailAddress);
        Task<UserToken> BuildToken(string emailAddress);
        Task<int> SaveUserRatingAsync(MovieRatingDTO movieRatingDTO);
        Task<int> SaveUserFavoriteMoviesAsync(UserFavoriteMoviesDTO userFavoriteMoviesDTO);
    }
}