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
            var aircrafts = await _aircraftservice.SelectAsync();
            var routes = await _routeService.SelectAsync();
            var airoports = await _airportService.SelectAsync();

            var aircraft = aircrafts.FirstOrDefault(x => x.Model == "B777-300ER");
            var aircraftID = aircraft.Id;
            var routeID = routes.FirstOrDefault(x =>
            {
                return x.DepartureAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "DXB").Id
                       && x.ArrivalAirport_ID == airoports.FirstOrDefault(y => y.Code_IATA == "IST").Id;
            }).Id;

            var startDate = new DateTime(2023, 3, 1);
            var endDate = new DateTime(2023, 7, 1);

            var morningTime = new DateTime(1, 1, 1, 10, 45, 0);
            var dayTime = new DateTime(1, 1, 1, 14, 20, 0);
            var eveningTime = new DateTime(1, 1, 1, 18, 00, 0);

            var flights = new List<Flight>();

            do
            {
                flights.Add(new Flight()
                {
                    AircraftID = aircraftID,
                    RouteID = routeID,
                    DepartureDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, morningTime.Hour, morningTime.Minute, 0),
                    ArrivalDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 14, 25, 0),
                    Luggage = true,
                    Food = true
                });

                if (startDate.DayOfWeek == DayOfWeek.Tuesday || startDate.DayOfWeek == DayOfWeek.Friday ||
                    startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    flights.Add(new Flight()
                    {
                        AircraftID = aircraftID,
                        RouteID = routeID,
                        DepartureDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, dayTime.Hour, dayTime.Minute, 0),
                        ArrivalDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 17, 55, 0),
                        Luggage = true,
                        Food = true
                    });

                    if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        flights.Add(new Flight()
                        {
                            AircraftID = aircraftID,
                            RouteID = routeID,
                            DepartureDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, eveningTime.Hour, eveningTime.Minute, 0),
                            ArrivalDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 21, 35, 0),
                            Luggage = true,
                            Food = true
                        });
                    }
                }

                startDate = startDate.AddDays(1);
            } while (startDate < endDate);

            var a = flights;
            await _flightService.InsertAsync(flights);

            var rates = new List<Rate>();
            foreach (var f in flights)
            {
                rates.AddRange(AddRates(f.Id));
            }

            var aa = rates;
            await _rateService.InsertAsync(rates);



            foreach (var f in flights)
            {
                var flightId = f.Id;

                var reservation = new Reservation()
                {
                    UserID = 2,
                    FlightID = flightId,
                    Paid = true
                };
                await _reservationService.InsertAsync(reservation);

                var reservationId = reservation.Id;

                var r = new Random();
                var occupancy = r.Next(75, 100);
                var percentageOfOccupancy = (double)occupancy / 100;

                int ecomonyPassengerCount = Convert.ToInt32(aircraft.EconomyClassSeats * percentageOfOccupancy);
                int businessPassengerCount = Convert.ToInt32(aircraft.BusinessClassSeats * percentageOfOccupancy);
                int firstPassengerCount = Convert.ToInt32(aircraft.FirstClassSeats * percentageOfOccupancy);
                int luggageCount = Convert.ToInt32((aircraft.EconomyClassSeats + aircraft.BusinessClassSeats + aircraft.FirstClassSeats) *
                                                   percentageOfOccupancy);

                var prices = new List<Price>();
                prices.Add(new Price()
                {
                    ReservationID = reservationId,
                    RateType = RateTypes.AdultEconomyFlight,
                    Cost = 390,
                    Amount = ecomonyPassengerCount
                });
                prices.Add(new Price()
                {
                    ReservationID = reservationId,
                    RateType = RateTypes.AdultBusinessFlight,
                    Cost = 2200,
                    Amount = businessPassengerCount
                });
                prices.Add(new Price()
                {
                    ReservationID = reservationId,
                    RateType = RateTypes.AdultFirstFlight,
                    Cost = 4250,
                    Amount = firstPassengerCount
                });
                prices.Add(new Price()
                {
                    ReservationID = reservationId,
                    RateType = RateTypes.Luggage,
                    Cost = 50,
                    Amount = luggageCount
                });

                await _priceService.InsertAsync(prices);
            }

            return View(true);
        }
        
        private List<Rate> AddRates(int flightId)
        {
            var rates = new List<Rate>();

            rates.Add(new Rate()
            {
                FlightID = flightId,
                RateType = RateTypes.AdultEconomyFlight,
                Price = 390
            });
            rates.Add(new Rate()
            {
                FlightID = flightId,
                RateType = RateTypes.AdultBusinessFlight,
                Price = 2200
            });
            rates.Add(new Rate()
            {
                FlightID = flightId,
                RateType = RateTypes.AdultFirstFlight,
                Price = 4250
            });

            rates.Add(new Rate()
            {
                FlightID = flightId,
                RateType = RateTypes.Food,
                Price = 50
            });
            rates.Add(new Rate()
            {
                FlightID = flightId,
                RateType = RateTypes.Luggage,
                Price = 50
            });

            return rates;
        }
    }
}






















/*var countries = new List<Country>();
countries.Add(new Country() { Name = "United Arab Emirates" });
await _countryService.InsertAsync(countries);*/

/*var airoports = new List<Airport>();
airoports.Add(new Airport()
{
    Code_IATA = "DXB",
    CountryID = countries.FirstOrDefault(x => x.Name == "United Arab Emirates").Id,
    City = "Dubai",
    TimeZone = 4
});
/*await _airportService.InsertAsync(airoports);*/

/*var routes = new List<Route>();
routes.Add(new Route()
{
    DepartureAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "DXB").Id,
    ArrivalAirport_ID = airoports.FirstOrDefault(x => x.Code_IATA == "IST").Id,
    Distance = 3030
});
await _routeService.InsertAsync(routes);*/


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
await _aircraftservice.InsertAsync(aircrafts);*/

/*var flights = new List<Flight>();
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
await _flightService.InsertAsync(flights);

var rates = new List<Rate>();
rates.Add(new Rate()
{
    FlightID = flights.FirstOrDefault(x => x.DepartureDate == new DateTime(2022, 12, 23, 10, 45, 0)).Id,
    RateType = RateTypes.AdultEconomyFlight,
    Price = 390,
});
await _rateService.InsertAsync(rates);*/
