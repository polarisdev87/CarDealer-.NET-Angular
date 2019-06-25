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
            // Domain to Dto
            CreateMap<Make, MakeDto>();
            CreateMap<Model, ModelDto>();
            CreateMap<Feature, FeatureDto>();


            // Dto to Domain
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vehdto => vehdto.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vehdto => vehdto.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vehdto => vehdto.Contact.Phone));

        }

    }
}
