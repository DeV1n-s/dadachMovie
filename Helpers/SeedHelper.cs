using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dadachMovie.Helpers
{
    public static class SeedHelper
    {
        public static List<TEntity> SeedData<TEntity>(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Static/Json";
            string fullPath = Path.Combine(currentDirectory, path, fileName);

            var result = new List<TEntity>();
            using (StreamReader reader = new StreamReader(fullPath))
            {
                string json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }

            return result;
        }
    }
}