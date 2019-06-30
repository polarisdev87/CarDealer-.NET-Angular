using System.Threading.Tasks;
using CarDealer.Core.Domain;
using CarDealer.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {

        public VehicleRepository(CarDealerDbContext context)
            : base(context)
        {
        }

        public async Task<Vehicle> GetById(int id, bool includeRelated = true)
        {
            if (!includeRelated)
            {
                return await _context.Vehicles.FindAsync(id);
            }


            return await _context.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(m => m.Make)

                .SingleOrDefaultAsync(v => v.Id == id);
        }

    }
}
