using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data.Configurations
{
    internal class PriceConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Price>();

            entityBuilder.ToTable("Prices");

            entityBuilder.HasOne(x => x.Reservation).WithMany(x => x.Prices);            
        }
    }
}
