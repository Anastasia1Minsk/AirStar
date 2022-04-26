using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Business.Interfaces;
using AirStar.Data.Interfaces;
using AirStar.Infrastructure.Bases;
using AirStar.Models;
using AirStar.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AirStar.Business.Services
{
    public class AircraftService : ServiceBase<Aircraft>, IAircraftService
    {
        private readonly IAircraftRepository _repository;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _hostEnvironment;

        public AircraftService(IAircraftRepository repository, IMapper mapper, 
            IWebHostEnvironment hostEnvironment) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<int> InsertAsync(AircraftViewModel aircraftViewModel)
        {
            var aircraft = _mapper.Map<Aircraft>(aircraftViewModel);
            
            var filePath = await SavingPicture(aircraftViewModel);
            aircraft.Picture = $"\\{filePath}";

            return await InsertAsync(aircraft);
        }

        public async Task<bool> UpdateAsync(AircraftViewModel aircraftViewModel)
        {
            var aircraft = _mapper.Map<Aircraft>(aircraftViewModel);

            if (aircraftViewModel.PictureFile != null)
            {
                var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", "aircrafts", Path.GetFileName(aircraftViewModel.Picture));
                File.Delete(filePath);

                filePath = await SavingPicture(aircraftViewModel);
                aircraft.Picture = $"\\{filePath}";
            } 

            return await UpdateAsync(aircraft);
        }

        public async Task<string> SavingPicture(AircraftViewModel aircraftViewModel)
        {
            var fileName = $"{Guid.NewGuid()}.jpg";

            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", "aircrafts", fileName);
            using (var fileStream = System.IO.File.Create(filePath))
            {
                await aircraftViewModel.PictureFile.CopyToAsync(fileStream);
            }

            return Path.Combine("images", "aircrafts", fileName);
        }

        public async Task<bool> DeletePicruteAsync(AircraftViewModel aircraftViewModel)
        {
            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", "aircrafts", Path.GetFileName(aircraftViewModel.Picture));
            File.Delete(filePath);

            return true;
        }
    }
}
