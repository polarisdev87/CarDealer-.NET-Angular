using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarDealer.Core.Domain
{
    public class Make
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<ModelDto> Models { get; set; }


        public Make()
        {
            Models = new Collection<ModelDto>();
        }
    }
}
