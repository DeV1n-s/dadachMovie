using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Enums;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface IRequestsService
    {
        Task<Paging<RequestDTO>> GetAllRequestsPagingAsync(GridifyQuery gridifyQuery);
        Task<int> NewRequestAsync(RequestCreationDTO requestCreationDTO);
        Task<int> ChangeRequestStatus(int id, RequestStatus requestStatus);
    }
}