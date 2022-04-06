using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data.Configurations
{
    internal class RouteConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Route>();

            entityBuilder.ToTable("Routes");

            entityBuilder.HasOne(x => x.DepartureAirport).WithMany(x => x.Routes);
            entityBuilder.HasOne(x => x.ArrivalAirport).WithMany(x => x.Routes);
            entityBuilder.HasMany(x => x.Flights).WithOne(x => x.Route);            
        }
    }
}
