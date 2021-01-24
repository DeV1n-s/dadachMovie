using System.Collections.Generic;

namespace dadachMovie.Entities
{
    public partial class Category
    {
        public Category()
        {
            People = new List<Person>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Person> People { get; set; }
    }
}