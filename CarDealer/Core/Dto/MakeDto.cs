﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Core.Domain;

namespace CarDealer.Core.Dto
{
    public class MakeDto : KeyValuePairDto
    {
       
        public ICollection<KeyValuePairDto> Models { get; set; }


        public MakeDto()
        {
            Models = new Collection<KeyValuePairDto>();
        }

    }
}
