using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data.Configurations
{
    internal class AirportConfiguratoin
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Airport>();

            entityBuilder.ToTable("Airports");

            entityBuilder.HasMany(x => x.Routes).WithOne(x => x.DepartureAirport);
            entityBuilder.HasMany(x => x.Routes).WithOne(x => x.ArrivalAirport);
        }
    }
}
