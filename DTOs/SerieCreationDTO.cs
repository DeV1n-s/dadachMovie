using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using dadachMovie.Enums;
using dadachMovie.Helpers;
using dadachMovie.Validations;
using Microsoft.AspNetCore.Http;

namespace dadachMovie.DTOs
{
    public class SerieCreationDTO
    {
        [Required, MaxLength(300)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Seasons { get; set; }
        public int? Episodes { get; set; }
        public SeriesStatus Status { get; set; }
        public DaysEnum? AirDay { get; set; }

        [JsonIgnore]
        public string ImdbRate { get; set; }

        [JsonIgnore]
        public string ImdbRatesCount { get; set; }

        [JsonIgnore]
        public string MetacriticRate { get; set; }
        public int? Lenght { get; set; }
        
        [Required]
        [ImdbIdValidator]
        public string ImdbId { get; set; }

        [FileSizeValidator(maxFileSizeInMbs: 5)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }

        [FileSizeValidator(maxFileSizeInMbs: 5)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile BannerImage { get; set; }

        [JsonIgnore]
        public List<int> GenresId { get; set; }

        [JsonIgnore]
        public List<CastCreationDTO> Casts { get; set; }

        [JsonIgnore]
        public List<int> DirectorsId { get; set; }

        [JsonIgnore]
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