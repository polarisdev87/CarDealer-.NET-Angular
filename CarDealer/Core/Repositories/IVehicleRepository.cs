﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;

namespace CarDealer.Core.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {

        Task<Vehicle> GetById(int id, bool includeRelated);

    }
}
