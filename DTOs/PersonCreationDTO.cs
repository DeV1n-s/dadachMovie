using System.Collections.Generic;
using System.Text.Json.Serialization;
using dadachMovie.Helpers;
using dadachMovie.Validations;
using Microsoft.AspNetCore.Http;

namespace dadachMovie.DTOs
{
    public class PersonCreationDTO: PersonPatchDTO
    {
        [FileSizeValidator(maxFileSizeInMbs: 4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }

        [JsonIgnore]
        [SwaggerIgnore]
        public List<int> CategoriesId { get; set; }

        public string CategoriesIdJson
        {
            get => SerializerHelper.Serialize(CategoriesId);
            set => CategoriesId = SerializerHelper.Deserialize<List<int>>(value);
        }
    }
}