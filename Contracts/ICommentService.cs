using System.Threading.Tasks;
using dadachMovie.DTOs;

namespace dadachMovie.Contracts
{
    public interface ICommentService
    {
        Task<int> SaveCommentAsync(CommentCreationDTO commentCreationDTO);
        Task<int> DeleteCommentAsync(int id);
    }
}