using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core.Domain;
using CarDealer.Core.Dto;
using CarDealer.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [Route("/api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;

        public VehicleController(CarDealerDbContext context, IMapper mapper)
        {

            this.mapper = mapper;
            this.context = context;

        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleDto vehicleDto)
        {
            var vehicle = mapper.Map<VehicleDto, Vehicle>(vehicleDto);

            vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleDto>(vehicle);

            return Ok(result);
        }
    }
}