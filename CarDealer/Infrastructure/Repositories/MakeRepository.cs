using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;
using CarDealer.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Infrastructure.Repositories
{
    public class MakeRepository : Repository<Make>, IMakeRepository
    {

        public MakeRepository(CarDealerDbContext context)
            : base(context)
        {

        }

        public async Task<List<Make>> GetAllMakesWithModelsAsync()
        {
            return await _context.Makes.Include(m => m.Models).ToListAsync();
        }

    }
}
