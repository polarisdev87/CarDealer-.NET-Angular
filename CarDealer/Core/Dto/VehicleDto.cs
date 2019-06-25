using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;

namespace CarDealer.Core.Dto
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        
        public ContactDto Contact { get; set; }

        public ICollection<int> Features { get; set; }

        public VehicleDto()
        {
            Features = new Collection<int>();
        }
    }
}
