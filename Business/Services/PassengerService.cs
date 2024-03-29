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
    public class PassengerService : ServiceBase<Passenger>, IPassengerService
    {
        private readonly IPassengerRepository _repository;
        public PassengerService(IPassengerRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
