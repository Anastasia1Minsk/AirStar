using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data.Configurations
{
    internal class CountryConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Country>();

            entityBuilder.ToTable("Countries");

            entityBuilder.HasMany(x => x.Airports).WithOne(x => x.Country);            
        }
    }
}
