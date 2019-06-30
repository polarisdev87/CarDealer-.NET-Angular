using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;
using CarDealer.Core.Repositories;

namespace CarDealer.Infrastructure.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {

        public ModelRepository(CarDealerDbContext context)
            : base(context)
        {
        }

    }
}
