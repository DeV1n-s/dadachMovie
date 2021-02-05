using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class UserFavoriteSeriesWithCountDTO
    {
        public int TotalItems { get; set; }
        public List<UserFavoriteSerieDTO> Items { get; set; }
    }
}