using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data.Configurations
{
    internal class ReservationConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Reservation>();

            entityBuilder.ToTable("Reservations");

            entityBuilder.HasMany(x => x.Passengers).WithOne(x => x.Reservation);
            entityBuilder.HasMany(x => x.Prices).WithOne(x => x.Reservation);
            entityBuilder.HasOne(x => x.User).WithMany(x => x.Reservations);
            entityBuilder.HasOne(x => x.Flight).WithMany(x => x.Reservations);
        }
    }
}
