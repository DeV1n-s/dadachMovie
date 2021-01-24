using System;
using System.Collections.Generic;
using dadachMovie.Entities;
using dadachMovie.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dadachMovie.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(SeedHelper.SeedData<Country>("countries.json"));
        }
    }
}