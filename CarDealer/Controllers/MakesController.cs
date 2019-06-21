using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;
using CarDealer.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly CarDealerDbContext context;

        public MakesController(CarDealerDbContext context)
        {
            this.context = context;
        }


        [HttpGet("/api/makes")]
        public IEnumerable<Make> GetMakes()
        {

        }

    }
}