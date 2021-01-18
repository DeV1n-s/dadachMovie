using System.Text.Json;

namespace dadachMovie.Helpers
{
    public static class SerializerHelper
   {
        public static T Deserialize<T>(string value) =>
            JsonSerializer.Deserialize<T>(value, GetJsonSerializerDefaultOptions());

        public static string Serialize<T>(T property) =>
            JsonSerializer.Serialize<T>(property, GetJsonSerializerDefaultOptions());

        private static JsonSerializerOptions GetJsonSerializerDefaultOptions()
        {
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;
            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            return jsonSerializerOptions;
        }
   }
}