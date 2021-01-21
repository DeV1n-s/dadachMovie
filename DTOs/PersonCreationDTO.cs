using dadachMovie.Validations;
using Microsoft.AspNetCore.Http;

namespace dadachMovie.DTOs
{
    public class PersonCreationDTO: PersonPatchDTO
    {
        [FileSizeValidator(maxFileSizeInMbs: 4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }
        public int CountryId { get; set; }
    }
}