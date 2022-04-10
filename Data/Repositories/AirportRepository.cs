using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Data.Interfaces;
using AirStar.Infrastructure.Bases;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;

namespace AirStar.Data.Repositories
{
    public class AirportRepository : RepositoryBase<Airport>, IAirportRepository
    {
        public AirportRepository(IDataContextFactory dataContextFactory) : base(dataContextFactory)
        { }
    }
}
