using System.Threading.Tasks;

namespace dadachMovie.Contracts
{
    public interface IBaseService
    {
        Task SaveChangesAsync();
        void SaveChanges();
    }
}