using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [Route("/api/vehicles")]
    public class VehicleController : Controller
    {

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] VehicleDto vehicleDto)
        {
            return Ok(vehicleDto);
        }
    }
}