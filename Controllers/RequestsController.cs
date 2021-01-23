using System.Threading.Tasks;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Enums;
using dadachMovie.Validations;
using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsService _requestsService;

        public RequestsController(IRequestsService requestsService)
        {
            _requestsService = requestsService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Paging<RequestDTO>>> GetRequests([FromQuery] GridifyQuery gridifyQuery) =>
            await _requestsService.GetAllRequestsPagingAsync(gridifyQuery);
        
        [HttpPost("NewRequest")]
        [ValidateModelAttribute]
        [Authorize]
        public async Task<ActionResult> PostNewRequest(RequestCreationDTO requestCreation)
        {
            var result = await _requestsService.NewRequestAsync(requestCreation);
            if (result == -1)
                return BadRequest("Failed to save changes.");
            
            return NoContent();
        }

        [HttpPut("UpdateStatus/{id:int}")]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
        public async Task<ActionResult> PutUpdateStatus(int id, RequestStatus requestStatus)
        {
            var result = await _requestsService.ChangeRequestStatus(id, requestStatus);
            if (result == -2)
                return NotFound();
            else if(result == -1)
                return BadRequest("Failed to save changes");
            
            return NoContent();
        }
    }
}