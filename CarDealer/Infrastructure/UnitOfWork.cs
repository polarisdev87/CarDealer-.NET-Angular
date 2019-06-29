using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core;

namespace CarDealer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        public readonly CarDealerDbContext _context;

        public UnitOfWork(CarDealerDbContext context)
        {
            _context = context;
        }


        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }

    }
}
