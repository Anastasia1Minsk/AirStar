using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;

namespace AirStar.Business.Interfaces
{
    public interface IAircraftService : IServiceBase<Aircraft>
    {
        public Task<int> InsertAsync(AircraftViewModel aircraftViewModel);
        public Task<bool> UpdateAsync(AircraftViewModel aircraftViewModel);
        public Task<bool> DeletePicruteAsync(Aircraft aircraft);
        public Task<bool> AircraftHasDependenciesAsync(int id);
    }
}
