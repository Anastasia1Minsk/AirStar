using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Data.Configurations;
using AirStar.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirStar.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AircraftConfiguration.Configure(modelBuilder);
            AirportConfiguratoin.Configure(modelBuilder);
            CountryConfiguration.Configure(modelBuilder);
            FlightConfiguration.Configure(modelBuilder);
            PassengerConfiguration.Configure(modelBuilder);
            PriceConfiguration.Configure(modelBuilder);
            RateConfiguration.Configure(modelBuilder);
            ReservationConfiguration.Configure(modelBuilder);
            RouteConfiguration.Configure(modelBuilder);
            UserConfiguration.Configure(modelBuilder);
        }
    }
}
