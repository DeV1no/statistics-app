using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StatisticsApp.DTO;
using StatisticsApp.Entity;

namespace StatisticsApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UTM, UtmDTO>().ReverseMap();
            CreateMap<UtmCreationDtO, UTM>();
        }
    }
}