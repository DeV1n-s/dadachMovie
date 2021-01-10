using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface IAccountsService
    {
        Task<Paging<UserDTO>> GetUsersPagingAsync(GridifyQuery gridifyQuery);
        Task<List<string>> GetRolesListAsync();
        Task<bool> AssignUserRoleAsync(EditRoleDTO editRoleDTO);
        Task<bool> RemoveUserRoleAsync(EditRoleDTO editRoleDTO);
        Task<UserToken> RegisterUserAsync(UserCreationDTO userCreationDTO);
        Task<UserToken> UserLoginAsync(UserInfo userInfo);
        Task<UserToken> RenewUserBearerTokenAsync(string emailAddress);
    }
}