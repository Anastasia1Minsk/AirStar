using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Data.Interfaces;
using AirStar.Infrastructure.Bases;
using AirStar.Infrastructure.Bases.Interfaces;
using AirStar.Models;
using AirStar.Models.Enums;
using AirStar.ViewModels;
using Microsoft.AspNetCore.Http;

namespace AirStar.Business.Services
{
    public class ReservationService : ServiceBase<Reservation>, IReservationService
    {
        private readonly IReservationRepository _repository;
        private readonly IPassengerService _passengerService;
        private readonly IPriceService _priceService;
        private readonly IUserService _userService;
        private readonly IRateService _rateService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReservationService(IReservationRepository repository, IPassengerService passengerService,
            IPriceService priceService, IUserService userService, IRateService rateService,
            IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            _repository = repository;
            _passengerService = passengerService;
            _priceService = priceService;
            _userService = userService;
            _rateService = rateService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CreateReservation(PassengerInformationViewModel passengerInformationViewModel)
        {
            var reservation = new Reservation();
            reservation.FlightID = passengerInformationViewModel.Flight.Id;

           /* var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userService.SelectOneAsync(predicate: user => user.Email == userEmail);*/

            var user = await GetCurrentUser();
            reservation.UserID = user.Id;

            await InsertAsync(reservation);

            var passengers = new List<Passenger>();
            for (int i = 0; i < passengerInformationViewModel.Reservation.NumberOfPassengers; i++)
            {
                passengers.Add(new Passenger()
                {
                    ReservationID = reservation.Id,
                    LastName = passengerInformationViewModel.Reservation.Passengers[i].LastName,
                    FirstName = passengerInformationViewModel.Reservation.Passengers[i].FirstName,
                    MiddleName = passengerInformationViewModel.Reservation.Passengers[i].MiddleName,
                    AgeStatus = passengerInformationViewModel.Reservation.Passengers[i].AgeStatus,
                    Food = passengerInformationViewModel.Reservation.Passengers[i].Food,
                    Luggage = passengerInformationViewModel.Reservation.Passengers[i].Luggage
                });
            }

            await _passengerService.InsertAsync(passengers);

            var rates = (await _rateService.GetRatesByFlightAsync(reservation.FlightID)).ToList();

            var prices = new List<Price>();
            var ticketRate = rates.FirstOrDefault(rate => rate.Id == passengerInformationViewModel.Reservation.ClassId);
            if (ticketRate != null)
            {
                prices.Add(new Price()
                {
                    ReservationID = reservation.Id,
                    RateType = ticketRate.RateType,
                    Cost = ticketRate.Price,
                    Amount = passengers.Count
                });
            }

            var foodAmount = passengers.Where(x => x.Food).ToList().Count();
            if (foodAmount > 0)
            {
                var foodRate = rates.FirstOrDefault(rate => rate.RateType == RateTypes.Food);
                if (foodRate != null)
                {
                    prices.Add(new Price()
                    {
                        ReservationID = reservation.Id,
                        RateType = foodRate.RateType,
                        Cost = foodRate.Price,
                        Amount = foodAmount
                    });
                }
            }

            var luggageAmount = passengers.Where(x => x.Luggage).ToList().Count();
            if (luggageAmount > 0)
            {
                var luggageRate = rates.FirstOrDefault(rate => rate.RateType == RateTypes.Luggage);
                if (luggageRate != null)
                {
                    prices.Add(new Price()
                    {
                        ReservationID = reservation.Id,
                        RateType = luggageRate.RateType,
                        Cost = luggageRate.Price,
                        Amount = luggageAmount
                    });
                }
            }

            await _priceService.InsertAsync(prices);

            return reservation.Id;
        }

        private async Task<User> GetCurrentUser ()
        {
            var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userService.SelectOneAsync(predicate: user => user.Email == userEmail);
            return user;
        }

        public async Task<IEnumerable<Reservation>> GetReservationByUser()
        {
            var user = await GetCurrentUser();

            var result = await SelectAsync(
                predicate: x => x.UserID == user.Id,
                includes: (new List<string>() { "Passengers", "Prices", "Flight", "Flight.Aircraft", "Flight.Route",
                    "Flight.Route.DepartureAirport", "Flight.Route.ArrivalAirport" }));

            return result;
        }
    }
}
