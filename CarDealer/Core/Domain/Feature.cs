using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Core.Domain
{
    [Table("Features")]
    public class Feature : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
