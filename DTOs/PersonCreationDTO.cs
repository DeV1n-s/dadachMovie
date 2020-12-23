using System.Collections.Generic;
using dadachMovie.Entities;
using dadachMovie.Helpers;
using dadachMovie.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.DTOs
{
    public class PersonCreationDTO: PersonPatchDTO
    {
        [FileSizeValidator(maxFileSizeInMbs: 4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }
        
        //[ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public int CountryId { get; set; }
    }
}