using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;

namespace CarDealer.Core.Dto
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
