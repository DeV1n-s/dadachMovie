using System.Collections.Generic;
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
        public List<int> GenresId { get; set; } = new List<int>();

        [ModelBinder(BinderType = typeof(TypeBinder<List<CasterCreationDTO>>))]
        public List<CasterCreationDTO> Casters { get; set; } = new List<CasterCreationDTO>();

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> DirectorsId { get; set; } = new List<int>();
    }
}