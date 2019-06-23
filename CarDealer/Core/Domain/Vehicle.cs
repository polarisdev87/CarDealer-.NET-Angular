using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Core.Domain
{
    public class Vehicle : BaseEntity
    {
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
        [StringLength(255)]
        public string ContactEmail { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
