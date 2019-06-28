using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core.Domain;
using CarDealer.Core.Dto;
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

        public VehicleController(CarDealerDbContext context, IMapper mapper)
        {

            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleDto = mapper.Map<Vehicle, SaveVehicleDto>(vehicle);

            return Ok(vehicleDto);
        }



        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleDto saveVehicleDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await context.Models.FindAsync(saveVehicleDto.ModelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid ModelId");
                return BadRequest(ModelState);
            }


            var vehicle = mapper.Map<SaveVehicleDto, Vehicle>(saveVehicleDto);

            // vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, SaveVehicleDto>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleDto saveVehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            mapper.Map(saveVehicleDto, vehicle);

            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, SaveVehicleDto>(vehicle);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            var vehicle = await context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            context.Remove(vehicle);

            await context.SaveChangesAsync();

            return Ok(id);

        }
    }
}