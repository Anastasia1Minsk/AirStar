using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Data.Interfaces;
using AirStar.Infrastructure.Bases;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;
using AirStar.ViewModels;

namespace AirStar.Business.Services
{
    public class FlightService : ServiceBase<Flight>, IFlightService
    {
        private readonly IFlightRepository _repository;
        public FlightService(IFlightRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IPagedList<Flight>> FlightSearchAsync(SearchViewModel searchViewModel, int page)
        {
            var suitableFlights = await SelectPageAsync(
                predicate: flight => flight.Route.DepartureAirport.Id == searchViewModel.DepartureAirportID
                                     && flight.Route.ArrivalAirport.Id == searchViewModel.ArrivalAirportID
                                     && flight.DepartureDate.Date == searchViewModel.DepartureDate
                                     && ((flight.Aircraft.EconomyClassSeats >= searchViewModel.NumberOfPassengers)
                                          || (flight.Aircraft.BusinessClassSeats >= searchViewModel.NumberOfPassengers)
                                          || (flight.Aircraft.FirstClassSeats >= searchViewModel.NumberOfPassengers)),
                includes: new List<string>() { "Aircraft", "Rates", "Route", "Route.DepartureAirport", "Route.ArrivalAirport" });
            return suitableFlights;
        }

        public async Task<IEnumerable<Flight>> SelectFlightsListAsync()
        {
            return await SelectAsync(includes: new List<string>() { "Aircraft", "Route",
                "Route.DepartureAirport", "Route.ArrivalAirport" });
        }

        public async Task<Flight> SelectOneFlightAsync(int id)
        {
            return await SelectOneAsync(predicate: x => x.Id == id,
                    includes: new List<string>() { "Aircraft", "Rates", "Route", "Route.DepartureAirport", "Route.ArrivalAirport"});
        }

        public async Task<bool> IsFlightExistsAsync(Flight flight)
        {
            var result = await SelectOneAsync(predicate: x => x.AircraftID == flight.AircraftID
                                                              && x.RouteID == flight.RouteID
                                                              && x.DepartureDate == flight.DepartureDate
                                                              && x.ArrivalDate == flight.ArrivalDate,
                                                    includes: new List<string>() { "Aircraft", "Route"});
            return result != null;
        }

        public async Task<bool> IsFlightUpdatesAsync(Flight flight)
        {
            var result = await SelectOneAsync(predicate: x => x.AircraftID == flight.AircraftID
                                                              && x.RouteID == flight.RouteID
                                                              && x.DepartureDate == flight.DepartureDate
                                                              && x.ArrivalDate == flight.ArrivalDate
                                                              && x.Id != flight.Id,
                                                    includes: new List<string>() { "Aircraft", "Route"});
            return result != null;
        }

        public async Task<bool> FlightHasDependencies(int id)
        {
            var result = await SelectOneAsync(predicate: x => x.Id == id,
                                                    includes: new List<string>() {"Reservations"});
            return result.Reservations.Any();
        }
    }
}
