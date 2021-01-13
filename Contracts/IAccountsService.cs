using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface IAccountsService
    {
        Task<Paging<UserDTO>> GetUsersPagingAsync(GridifyQuery gridifyQuery);
        Task<UserDTO> GetCurrentUserAsync();
        Task<UserDTO> GetUserByEmailAsync(string emailAddress);
        Task<List<string>> GetRolesListAsync();
        Task<int> AssignUserRoleAsync(EditRoleDTO editRoleDTO);
        Task<int> RemoveUserRoleAsync(EditRoleDTO editRoleDTO);
        Task<UserToken> RegisterUserAsync(UserCreationDTO userCreationDTO);
        Task<UserToken> UserLoginAsync(UserInfo userInfo);
        Task<UserToken> RenewUserBearerTokenAsync(string emailAddress);
        Task<int> UpdateUserAsync(UserUpdateDTO userUpdateDTO);
    }
}