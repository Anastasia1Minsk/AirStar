using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Models;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data.Configurations
{
    internal class UserConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<User>();

            entityBuilder.ToTable("Users");

            entityBuilder.HasMany(x => x.Reservations).WithOne(x => x.User);            
        }
    }
}
