﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Data.Interfaces;
using AirStar.Infrastructure.Bases;
using AirStar.Models;

namespace AirStar.Business.Services
{
    public class RouteService : ServiceBase<Route>, IRouteService
    {
        private readonly IRouteRepository _repository;
        public RouteService(IRouteRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Route>> SelectWithAirportsAsync()
        {
            return await SelectAsync(includes: new List<string>() { "DepartureAirport", "ArrivalAirport", "DepartureAirport.Country", "ArrivalAirport.Country" });
        }

        public async Task<Route> SelectOneWithAirportsAsync(int id)
        {
            return await SelectOneAsync(predicate: x => x.Id == id,
                includes: new List<string>() { "DepartureAirport", "ArrivalAirport", "DepartureAirport.Country", "ArrivalAirport.Country" });
        }

        public async Task<bool> IsRouteExistsAsync(int departureAirport_ID, int arrivalAirport_ID)
        {
            var result = await SelectOneAsync(predicate: x => x.DepartureAirport_ID == departureAirport_ID 
                                                              && x.ArrivalAirport_ID == arrivalAirport_ID);
            return result != null;
        }

        public async Task<bool> IsRouteUpdatesAsync(int departureAirport_ID, int arrivalAirport_ID, int routeId)
        {
            var result = await SelectOneAsync(predicate: x => x.DepartureAirport_ID == departureAirport_ID
                                                              && x.ArrivalAirport_ID == arrivalAirport_ID
                                                              && x.Id != routeId);
            return result != null;
        }

        public async Task<bool> RouteHasDependenciesAsync(int id)
        {
            var route = await SelectOneAsync(predicate: x => x.Id == id,
                                            includes: new List<string>() {"Flights"});
            return route.Flights.Any();
        }

        public async Task<IEnumerable<Route>> SelectForLastThreeMonthsAsync()
        {
            var firstDayOfCurrentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var threeMonthAgo = firstDayOfCurrentMonth.AddMonths(-3);

            var routes = await SelectAsync(predicate: x => x.Flights
                                                                                .Any(f => f.DepartureDate >= threeMonthAgo 
                                                                                    && f.DepartureDate < firstDayOfCurrentMonth
                                                                                    && f.Canceled == false),
                includes: new List<string>() {"DepartureAirport", "ArrivalAirport", "Flights" });
            
            return routes;
        }
    }
}
