using System.Collections.Generic;
using System.Text.Json.Serialization;
using dadachMovie.Helpers;
using dadachMovie.Validations;
using Microsoft.AspNetCore.Http;

namespace dadachMovie.DTOs
{
    public class MovieCreationDTO : MoviePatchDTO
    {
        [FileSizeValidator(maxFileSizeInMbs: 4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }

        [JsonIgnore]
        [SwaggerIgnore]
        public List<int> GenresId { get; set; }

        [JsonIgnore]
        [SwaggerIgnore]
        public List<CastCreationDTO> Casts { get; set; }

        [JsonIgnore]
        [SwaggerIgnore]
        public List<int> DirectorsId { get; set; }

        [JsonIgnore]
        [SwaggerIgnore]
        public List<int> CountriesId { get; set; }

        public string CountriesIdJson
        {
            get => SerializerHelper.Serialize(CountriesId);
            set => CountriesId = SerializerHelper.Deserialize<List<int>>(value);
        }

        public string DirectorsIdJson
        {
            get => SerializerHelper.Serialize(DirectorsId);
            set => DirectorsId = SerializerHelper.Deserialize<List<int>>(value);
        }

        public string GenresIdJson
        {
            get => SerializerHelper.Serialize(GenresId);
            set => GenresId = SerializerHelper.Deserialize<List<int>>(value);
        }

        public string CastsJson
        {
            get => SerializerHelper.Serialize(Casts);
            set => Casts = SerializerHelper.Deserialize<List<CastCreationDTO>>(value);
        }
    }
}