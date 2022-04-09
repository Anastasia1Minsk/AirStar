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
    public class RateRepository : RepositoryBase<Rate>, IRateRepository
    {
        public RateRepository(IDataContextFactory dataContextFactory) : base(dataContextFactory)
        { }
    }
}
