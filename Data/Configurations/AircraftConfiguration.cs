using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data.Configurations
{
    internal class AircraftConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Aircraft>();

            entityBuilder.ToTable("Aircrafts");

            entityBuilder.HasMany(x => x.Flights).WithOne(x => x.Aircraft);            
        }
    }
}
