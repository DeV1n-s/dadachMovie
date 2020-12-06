using System.Collections.Generic;
using dadachAPI.Helpers;
using dadachAPI.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dadachAPI.DTOs
{
    public class MovieCreationDTO : MoviePatchDTO
    {
        [FileSizeValidator(maxFileSizeInMbs: 4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenresId { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<CasterCreationDTO>>))]
        public List<CasterCreationDTO> Casters { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<DirectorCreationDTO>>))]
        public List<DirectorCreationDTO> Directors { get; set; }
    }
}