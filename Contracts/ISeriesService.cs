using System.Linq;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface ISeriesService : IBaseService
    {
        Task<Paging<SerieDTO>> GetSeriesPagingAsync(int? genreId, GridifyQuery gridifyQuery);
        Task<SerieDetailsDTO> GetSerieDetailsByIdAsync(int id);
        Task<Serie> GetSerieByIdAsync(int id);
        Task<Paging<SerieDTO>> GetSeriesByGenreIdPagingAsync(int id, GridifyQuery gridifyQuery);
        Task<Paging<SerieDTO>> GetUpcomingReleasesAsync(GridifyQuery gridifyQuery);
        IQueryable<SerieDetailsDTO> GetSeriesDetailsQueryable();
        IQueryable<Serie> GetSeriesQueryable();
        Task<SerieDTO> AddSerieAsync(SerieCreationDTO serieCreationDTO);
        Task<int> UpdateSerieAsync(int id, SerieCreationDTO serieCreationDTO);
        Task<int> DeleteSerieAsync(int id);
        Task<int> CheckImdbIdAsync(string imdbId);
        Task<int> AddUserCommentAsync(CommentCreationDTO commentCreationDTO);
        Task<int> DeleteUserCommentAsync(int id);
        Task<int> SaveUserSerieRatingAsync(SerieRatingDTO serieRatingDTO);
        Task<int> SaveUserFavoriteSeriesAsync(UserFavoriteSeriesDTO userFavoriteSeriesDTO);
        Task SetSerieRatingsAsync(Serie serie);
        void AnnotateCastsOrder(Serie serie);
        Task SetSerieDirectorsGenresCastsListAsync(Serie serie, SerieCreationDTO serieCreationDTO);
    }
}