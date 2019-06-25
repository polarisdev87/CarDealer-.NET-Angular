using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [Route("/api/vehicles")]
    public class VehicleController : Controller
    {

        [HttpPost]
        public IActionResult CreateVehicle()
        {

        }
    }
}