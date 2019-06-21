using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core.Domain;
using CarDealer.Core.Dto;
using CarDealer.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Controllers
{
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;

        public MakesController(CarDealerDbContext context, IMapper mapper)
        {

            this.mapper = mapper;
            this.context = context;

        }


        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeDto>> GetMakes()
        {
            var makes = await context.Makes.ToListAsync();

            return mapper.Map<List<Make>, List<MakeDto>>(makes);
        }

    }
}