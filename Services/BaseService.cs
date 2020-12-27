using System.Threading.Tasks;
using dadachMovie.Contracts;

namespace dadachMovie.Services
{
    public class BaseService : IBaseService
    {
        private readonly AppDbContext _dbContext;

        public BaseService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SaveChanges() =>
            _dbContext.SaveChanges();

        public async Task SaveChangesAsync() =>
            await _dbContext.SaveChangesAsync();
    }
}