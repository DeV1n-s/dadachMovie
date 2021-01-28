using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class UserActivitiesService : IUserActivitiesService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserActivitiesService(AppDbContext dbContext,
                                    IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Paging<UserActivityDTO>> GetUserActivitiesPagingAsync(string userEmail, string ipAddress, GridifyQuery gridifyQuery)
        {
            QueryablePaging<UserActivity> queryable;
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                queryable = await _dbContext.UserActivities.AsNoTracking().Where(x => x.IpAddress == ipAddress && x.UserName == null)
                                                        .GridifyQueryableAsync(gridifyQuery,null);
            } else {
                queryable = await _dbContext.UserActivities.AsNoTracking().Where(x => x.UserName == userEmail)
                                                        .GridifyQueryableAsync(gridifyQuery,null);
            }
            
            return new Paging<UserActivityDTO> {Items = queryable.Query.ProjectTo<UserActivityDTO>(_mapper.ConfigurationProvider).ToList(),
                                                TotalItems = queryable.TotalItems};
        }
    }
}