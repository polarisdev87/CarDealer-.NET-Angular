﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarDealer.Core.Domain
{
    public class Make : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }


        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}
