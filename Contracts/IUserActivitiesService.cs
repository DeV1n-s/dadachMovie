using System.Threading.Tasks;
using dadachMovie.DTOs;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface IUserActivitiesService
    {
        Task<Paging<UserActivityDTO>> GetUserActivitiesPagingAsync(string userEmail, string ipAddress, GridifyQuery gridifyQuery);
    }
}