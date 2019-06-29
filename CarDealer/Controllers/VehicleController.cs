using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core;
using CarDealer.Core.Domain;
using CarDealer.Core.Dto;
using CarDealer.Core.Repositories;
using CarDealer.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Controllers
{
    [Route("/api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IVehicleRepository _vehicleRepository;
        private readonly IModelRepository _modelRepository;

        public VehicleController(CarDealerDbContext context, IMapper mapper, IVehicleRepository vehicleRepository, IModelRepository modelRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _vehicleRepository = vehicleRepository;
            _modelRepository = modelRepository;

            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _vehicleRepository.GetById(id, true);

            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleDto = mapper.Map<Vehicle, VehicleDto>(vehicle);

            return Ok(vehicleDto);
        }



        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleDto saveVehicleDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _modelRepository.GetById(saveVehicleDto.ModelId);

            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid ModelId");
                return BadRequest(ModelState);
            }


            var vehicle = mapper.Map<SaveVehicleDto, Vehicle>(saveVehicleDto);

            // vehicle.LastUpdate = DateTime.Now;
            await _vehicleRepository.Create(vehicle);

            await context.SaveChangesAsync();

            vehicle = await _vehicleRepository.GetById(vehicle.Id, true);

            var result = mapper.Map<Vehicle, VehicleDto>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleDto saveVehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _vehicleRepository.GetById(id, true);

            if (vehicle == null)
            {
                return NotFound();
            }

            mapper.Map(saveVehicleDto, vehicle);

            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleDto>(vehicle);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            var vehicle = await _vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            await _vehicleRepository.Delete(vehicle.Id);

            await context.SaveChangesAsync();

            return Ok(id);

        }
    }
}