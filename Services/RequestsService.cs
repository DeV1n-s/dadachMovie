using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using dadachMovie.Enums;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class RequestsService : IRequestsService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILoggerService _logger;

        public RequestsService(AppDbContext dbContext,
                            IMapper mapper,
                            IHttpContextAccessor httpContextAccessor,
                            ILoggerService logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<int> NewRequestAsync(RequestCreationDTO requestCreationDTO)
        {
            var currentUserEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == currentUserEmail);
            requestCreationDTO.UserId = user.Id;

            var request = _mapper.Map<Request>(requestCreationDTO);
            _dbContext.Requests.Add(request);
            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"Request with ID {request.Id} was saved successfully.");
                return 1;
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to save request with ID {request.Id}. Exception: {ex}");
                return -1;
            }
        }

        public async Task<int> ChangeRequestStatus(int id, RequestStatus requestStatus)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == id);
            if (request == null)
            {
                _logger.LogWarn($"Requst with ID {id} was not found.");
                return -2;
            }
            request.Status = requestStatus;

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"Status of request with ID {id} was successfully changed to {requestStatus}");
                return 1;
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to change status of request with ID {id}. Exception: {ex}");
                return -1;
            }
        }

        public async Task<Paging<RequestDTO>> GetAllRequestsPagingAsync(GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Requests.GridifyQueryableAsync(gridifyQuery,null);

            return new Paging<RequestDTO> {Items = queryable.Query.ProjectTo<RequestDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
        }
    }
}