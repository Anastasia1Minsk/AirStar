using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirStar.Data
{
    public class DataContextFactory : IDataContextFactory
    {        
        private readonly IConfiguration _configuration;

        public DataContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDataContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseSqlServer(_configuration["DB:ConnectionString"]);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
