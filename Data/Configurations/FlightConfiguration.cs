using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data.Configurations
{
    internal class FlightConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Flight>();

            entityBuilder.ToTable("Flights");

            entityBuilder.HasOne(x => x.Aircraft).WithMany(x => x.Flights);
            entityBuilder.HasOne(x => x.Route).WithMany(x => x.Flights);
            entityBuilder.HasMany(x => x.Rates).WithOne(x => x.Flight);
            entityBuilder.HasMany(x => x.Reservations).WithOne(x => x.Flight);
        }
    }
}
