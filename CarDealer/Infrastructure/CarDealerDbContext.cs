using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Infrastructure
{
    public class CarDealerDbContext : DbContext
    {

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }


        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {

        }

    }
}
