using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MVCInventory.Business.Models;
using MVCInventory.Domain;

namespace MVCInventory.Business
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Building, BuildingModel>();
            CreateMap<FacilityAttachment, FacilityAttachmentModel>()
                .ForSourceMember(m => m.Facility, opt => opt.Ignore())
                .ForSourceMember(m => m.FacilityId, opt => opt.Ignore())
                .ReverseMap()
                .ForSourceMember(m => m.FacilityName, opt => opt.Ignore());
            CreateMap<Facility, FacilityModel>()
                .ReverseMap()
                .ForSourceMember(m => m.FacilityAttachments, opt => opt.Ignore())
            .ForMember(m => m.FacilityAttachments, opt => opt.Ignore());
            //.ForSourceMember(m => m.Building, opt => opt.Ignore());
        }

        //private static void ConfigureFacilityMappings()
        //{
        // Data --> Business
        //CreateMap<Facility, FacilityModel>();
        //.ReverseMap()
        //.ForSourceMember(m => m.IsNew, opt => opt.Ignore())
        //.ForMember(m => m.Category, opt => opt.UseValue(null))
        //.ForMember(m => m.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
        //.ForMember(m => m.TypeEnumId, opt => opt.MapFrom(src => src.Type.Id))
        //.ForMember(m => m.Type, opt => opt.UseValue(null));


        //Mapper.CreateMap<UserTest, UserTestModel>()
        //    .ReverseMap()
        //    .ForSourceMember(m => m.TestStatus, opt => opt.Ignore())
        //    .ForSourceMember(m => m.ExpiresDate, opt => opt.Ignore())
        //    .ForSourceMember(m => m.RecertifyDate, opt => opt.Ignore());


        // }
    }
}
