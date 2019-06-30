using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;

namespace CarDealer.Core.Repositories
{
    public interface IMakeRepository : IRepository<Make>
    {

        Task<List<Make>> GetAllMakesWithModelsAsync();

    }
}
