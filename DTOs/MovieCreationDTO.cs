using System.Collections.Generic;
using dadachMovie.Entities;
using dadachMovie.Helpers;
using dadachMovie.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.DTOs
{
    public class MovieCreationDTO : MoviePatchDTO
    {
        [FileSizeValidator(maxFileSizeInMbs: 4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenresId { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<CastCreationDTO>>))]
        public List<CastCreationDTO> Casts { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> DirectorsId { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> CountriesId { get; set; }
    }
}