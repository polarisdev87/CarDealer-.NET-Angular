using CarDealer.Core.Domain;
using CarDealer.Core.Repositories;

namespace CarDealer.Infrastructure.Repositories
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {

        public FeatureRepository(CarDealerDbContext context)
            : base(context)
        {
        }

    }
}
