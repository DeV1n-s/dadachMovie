using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dadachMovie.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Cast"
                },
                new Category
                {
                    Id = 2,
                    Name = "Director"
                },
                new Category
                {
                    Id = 3,
                    Name = "Writer"
                }
            );
        }
    }
}