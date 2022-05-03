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

            entityBuilder.HasOne(x => x.DepartureAirport).WithMany(x => x.DepartureRoutes)
                .HasForeignKey(x => x.DepartureAirport_ID);
            entityBuilder.HasOne(x => x.ArrivalAirport).WithMany(x => x.ArrivalRoutes)
                .HasForeignKey(x => x.ArrivalAirport_ID);
            entityBuilder.HasMany(x => x.Flights).WithOne(x => x.Route);
        }
    }
}
