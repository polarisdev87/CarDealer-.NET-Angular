using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        public IActionResult CreateVehicle([FromBody] VehicleDto vehicleDto)
        {
            return Ok(vehicleDto);
        }
    }
}