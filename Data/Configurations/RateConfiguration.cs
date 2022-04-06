using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data.Configurations
{
    internal class RateConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Rate>();

            entityBuilder.ToTable("Rates");

            entityBuilder.HasOne(x => x.Flight).WithMany(x => x.Rates);            
        }
    }
}
