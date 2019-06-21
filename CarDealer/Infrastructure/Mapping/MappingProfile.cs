    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    using AutoMapper;
    using CarDealer.Core.Domain;
    using CarDealer.Core.Dto;

    namespace CarDealer.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Make, MakeDto>();
            CreateMap<Model, ModelDto>();
        }

    }
}
