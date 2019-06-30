using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;
using CarDealer.Core.Repositories;

namespace CarDealer.Infrastructure.Repositories
{
    public class MakeRepository : Repository<Make>, IMakeRepository
    {

        public MakeRepository(CarDealerDbContext context)
            : base(context)
        {

        }

    }
}
