﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public override async Task<Vehicle> GetById(int id)
        {
           
        }

    }
}
