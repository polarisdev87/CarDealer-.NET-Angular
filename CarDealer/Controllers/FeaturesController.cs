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
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly CarDealerDbContext context;
        private readonly IMapper mapper;

        public FeaturesController(CarDealerDbContext context, IMapper mapper)
        {

            this.mapper = mapper;
            this.context = context;

        }


        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairDto>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();

            return mapper.Map<List<Feature>, List<KeyValuePairDto>>(features);
        }

    }
}