using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Data.Interfaces
{
    public interface IDataContextFactory
    {
        IDataContext Create();
    }
}
