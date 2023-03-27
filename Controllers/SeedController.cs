using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Models;
using AirStar.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AirStar.Controllers
{
    public class SeedController : Controller
    {
        private readonly IAircraftService _aircraftservice;
        private readonly IAirportService _airportService;
        private readonly ICountryService _countryService;
        private readonly IFlightService _flightService;
        private readonly IPassengerService _passengerService;
        private readonly IPriceService _priceService;
        private readonly IRateService _rateService;
        private readonly IReservationService _reservationService;
        private readonly IRouteService _routeService;
        private readonly IUserService _userService;

        public SeedController(IAircraftService aircraftServiceservice, IAirportService airportService, ICountryService countryService,
            IFlightService flightService, IPassengerService passengerService, IPriceService priceService, IRateService rateService,
            IReservationService reservationService, IRouteService routeService, IUserService userService)
        {
            _aircraftservice = aircraftServiceservice;
            _airportService = airportService;
            _countryService = countryService;
            _flightService = flightService;
            _passengerService = passengerService;
            _priceService = priceService;
            _rateService = rateService;
            _reservationService = reservationService;
            _routeService = routeService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            /*var countries = new List<Country>();
            countries.Add(new Country() { Name = "United Arab Emirates" });
            countries.Add(new Country() { Name = "Turkey" });
            countries.Add(new Country() { Name = "Great Britain" });
            countries.Add(new Country() { Name = "Japan" });
            countries.Add(new Country() { Name = "Sweden" });
            countries.Add(new Country() { Name = "Egypt" });*/
            /*await _countryService.InsertAsync(countries);*/


            /*var airoports = new List<Airport>();
            airoports.Add(new Airport()
            {
                Code_IATA = "DXB",
                CountryID = countries.FirstOrDefault(x => x.Name == "United Arab Emirates").Id,
                City = "Dubai",
                TimeZone = 4
            });
            airoports.Add(new Airport()
            {
                Code_IATA = "IST",
                CountryID = countries.FirstOrDefault(x => x.Name == "Turkey").Id,
                City = "Istanbul",
                TimeZone = 3
            });
            airoports.Add(new Airport()
            {
                Code_IATA = "LHR",
                CountryID = countries.FirstOrDefault(x => x.Name == "Great Britain").Id,
                City = "London",
                TimeZone = 1
            });
            airoports.Add(new Airport()
            {
                Code_IATA = "NRT",
                CountryID = countries.FirstOrDefault(x => x.Name == "Japan").Id,
                City = "Tokyo",
                TimeZone = 9
            });
            airoports.Add(new Airport()
            {
                Code_IATA = "ARN",
                CountryID = countries.FirstOrDefault(x => x.Name == "Sweden").Id,
                City = "Stockholm",
                TimeZone = 2
            });
            airoports.Add(new Airport()
            {
                Code_IATA = "CAI",
                CountryID = countries.FirstOrDefault(x => x.Name == "Egypt").Id,
                City = "Cairo",
                TimeZone = 2
            });*/
            /*await _airportService.InsertAsync(airoports);*/


            /*var routes = new List<Route>();
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "IST").Id,
                Distance = 3030
            });
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "IST").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                Distance = 3030
            });
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "LHR").Id,
                Distance = 5505
            });
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "LHR").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                Distance = 5505
            });
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "NRT").Id,
                Distance = 7994
            });
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "NRT").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                Distance = 7994
            });
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "ARN").Id,
                Distance = 4787
            });
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "ARN").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                Distance = 4787
            });
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "CAI").Id,
                Distance = 2419
            });
            routes.Add(new Route()
            {
                DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "CAI").Id,
                ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
                Distance = 2419

            });*/
            /*await _routeService.InsertAsync(routes);*/


            /*var aircrafts = new List<Aircraft>();
            aircrafts.Add(new Aircraft()
            {
                Model = "A380-800",
                Brand = "Airbus",
                YearOfBuild = 2015,
                EconomyClassSeats = 400,
                BusinessClassSeats = 76,
                FirstClassSeats = 16,
                MaxFlightRange = 15000,
                Picture = "/images/aircrafts/airbus A380-841.jpg"
            });
            aircrafts.Add(new Aircraft()
            {
                Model = "B777-300ER",
                Brand = "Boeing",
                YearOfBuild = 2019,
                EconomyClassSeats = 108,
                BusinessClassSeats = 80,
                FirstClassSeats = 8,
                MaxFlightRange = 14900,
                Picture = "/images/aircrafts/boeing 777-300ER.jpg"
            });*/
            /*await _aircraftservice.InsertAsync(aircrafts);*/

            
            var aircrafts = await _aircraftservice.SelectAsync();
            var routes = await _routeService.SelectAsync();
            var airoports = await _airportService.SelectAsync();

            var flights = new List<Flight>();
            flights.Add( new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "A380-800").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "IST").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 23, 10, 45, 0),
                ArrivalDate = new DateTime(2022, 12, 23, 14, 25, 0),
                Luggage = true,
                Food = true
            });
            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "A380-800").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "IST").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 23, 16, 25, 0),
                ArrivalDate = new DateTime(2022, 12, 23, 21, 50, 0),
                Luggage = true,
                Food = true
            });

            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "A380-800").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "IST").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 23, 23, 50, 0),
                ArrivalDate = new DateTime(2022, 12, 24, 4, 30, 0),
                Luggage = true,
                Food = true
            });
            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "A380-800").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "IST").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 24, 6, 30, 0),
                ArrivalDate = new DateTime(2022, 12, 24, 10, 55, 0),
                Luggage = true,
                Food = true
            });

            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "A380-800").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "LHR").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 24, 2, 30, 0),
                ArrivalDate = new DateTime(2022, 12, 24, 7, 5, 0),
                Luggage = true,
                Food = true
            });
            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "A380-800").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "LHR").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 24, 16, 50, 0),
                ArrivalDate = new DateTime(2022, 12, 25, 2, 45, 0),
                Luggage = true,
                Food = true
            });
            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "B777-300ER").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "NRT").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 25, 2, 40, 0),
                ArrivalDate = new DateTime(2022, 12, 25, 17, 35, 0),
                Luggage = true,
                Food = true
            });
            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "B777-300ER").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "NRT").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 25, 22, 30, 0),
                ArrivalDate = new DateTime(2022, 12, 26, 4, 50, 0),
                Luggage = true,
                Food = true
            });
            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "B777-300ER").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "ARN").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 27, 8, 40, 0),
                ArrivalDate = new DateTime(2022, 12, 27, 13, 10, 0),
                Luggage = true,
                Food = true
            });
            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "B777-300ER").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "ARN").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 27, 15, 5, 0),
                ArrivalDate = new DateTime(2022, 12, 27, 23, 20, 0),
                Luggage = true,
                Food = true
            });
            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "A380-800").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "CAI").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 28, 15, 15, 0),
                ArrivalDate = new DateTime(2022, 12, 28, 17, 5, 0),
                Luggage = true,
                Food = true
            });
            flights.Add(new Flight()
            {
                AircraftID = aircrafts.FirstOrDefault(x => x.Model == "A380-800").Id,
                RouteID = routes.FirstOrDefault(x =>
                {
                    return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "CAI").Id
                           && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id;
                }).Id,
                DepartureDate = new DateTime(2022, 12, 28, 19, 5, 0),
                ArrivalDate = new DateTime(2022, 12, 29, 0, 40, 0),
                Luggage = true,
                Food = true
            });
            await _flightService.InsertAsync(flights);


            var rates = new List<Rate>();
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 10, 45, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 390,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 10, 45, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 2200,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 10, 45, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 4250,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 10, 45, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 10, 45, 0)).Id,
                RateType = RateTypes.Food,
                Price = 50,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 16, 25, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 390,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 16, 25, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 2200,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 16, 25, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 4250,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 16, 25, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 16, 25, 0)).Id,
                RateType = RateTypes.Food,
                Price = 50,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 23, 50, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 390,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 23, 50, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 2200,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 23, 50, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 4250,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 23, 50, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 23, 50, 0)).Id,
                RateType = RateTypes.Food,
                Price = 50,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 6, 30, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 390,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 6, 30, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 2200,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 6, 30, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 4250,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 6, 30, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 6, 30, 0)).Id,
                RateType = RateTypes.Food,
                Price = 50,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 2, 30, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 560,
            });//3
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 2, 30, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 2610,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 2, 30, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 7680,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 2, 30, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 2, 30, 0)).Id,
                RateType = RateTypes.Food,
                Price = 70,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 16, 50, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 560,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 16, 50, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 2610,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 16, 50, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 7680,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 16, 50, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 24, 16, 50, 0)).Id,
                RateType = RateTypes.Food,
                Price = 70,
            });
            
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 2, 40, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 1080,
            });//5
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 2, 40, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 3900,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 2, 40, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 7300,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 2, 40, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 2, 40, 0)).Id,
                RateType = RateTypes.Food,
                Price = 100,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 22, 30, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 1080,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 22, 30, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 3900,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 22, 30, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 7300,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 22, 30, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 25, 22, 30, 0)).Id,
                RateType = RateTypes.Food,
                Price = 100,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 8, 40, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 565,
            });//7
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 8, 40, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 3110,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 8, 40, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 6410,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 8, 40, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 8, 40, 0)).Id,
                RateType = RateTypes.Food,
                Price = 60,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 15, 5, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 565,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 15, 5, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 3110,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 15, 5, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 6410,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 15, 5, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 27, 15, 5, 0)).Id,
                RateType = RateTypes.Food,
                Price = 60,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 15, 15, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 260,
            });//9
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 15, 15, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 1330,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 15, 15, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 3310,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 15, 15, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 15, 15, 0)).Id,
                RateType = RateTypes.Food,
                Price = 40,
            });

            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 19, 5, 0)).Id,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 260,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 19, 5, 0)).Id,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 1330,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 19, 5, 0)).Id,
                RateType = RateTypes.AdultFirstFlight,
                Price = 3310,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 19, 5, 0)).Id,
                RateType = RateTypes.Luggage,
                Price = 50,
            });
            rates.Add(new Rate()
            {
                FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 28, 19, 5, 0)).Id,
                RateType = RateTypes.Food,
                Price = 40,
            });
            await _rateService.InsertAsync(rates);

            return View(true);
        }
    }
}
