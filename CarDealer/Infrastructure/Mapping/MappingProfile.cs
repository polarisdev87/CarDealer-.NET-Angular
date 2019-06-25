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
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(vdto => vdto.Contact,
                    opt => opt.MapFrom(v => new ContactDto
                        { Name = v.ContactName, Phone = v.ContactPhone, Email = v.ContactEmail }))

                .ForMember(vdto => vdto.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));


            // Dto to Domain
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vdto => vdto.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vdto => vdto.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vdto => vdto.Contact.Phone))

                .ForMember(v => v.Features,
                    opt => opt.Ignore())
                
                .AfterMap((vdto, v) =>
                {
                    // Remove
                    var removedFeatures = v.Features.Where(f => !vdto.Features.Contains(f.FeatureId));

                    foreach (var rf in removedFeatures)
                    {
                        v.Features.Remove(rf);
                    }



                    // Add
                    var addedFeatures = vdto.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id});

                    foreach (var af in addedFeatures)
                    {
                        v.Features.Add(af);
                    }
 



                });

        }

    }
}
