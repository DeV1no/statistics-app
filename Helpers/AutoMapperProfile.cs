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
            //utm map
            CreateMap<UTM, UtmDTO>().ReverseMap();
            CreateMap<UtmCreationDtO, UTM>();
            CreateMap<UTM, UtmDetailDTO>()
                .ForMember(x => x.IndustryFinancial,
                    opt => opt.MapFrom(MapTaxToUTM)
                );
            //tax map
            CreateMap<TaxRate, TaxDTO>().ReverseMap();
            CreateMap<TaxtCreationDTO, TaxRate>();
            // industry financial
            CreateMap<IndustryFinancial, IndustryFinancialDTO>().ReverseMap();
            CreateMap<IndustryFinancialCreationDTO, IndustryFinancial>().
                ForMember(x=> x.FinancialToIndustries
                ,opt => opt.MapFrom(MapTaxToUTM));
                

        }

        //Map to Utm Function
        private List<IndustryFinancialDTO> MapTaxToUTM(UTM utm, UtmDetailDTO utmDetailDto)
        {
            var result = new List<IndustryFinancialDTO>();
            foreach (var tTu in utm.FinancialToIndustries)
            {
                result.Add(new IndustryFinancialDTO()

                {
                    Id = tTu.IndustryFinancial.Id,
                    AverageSalary = tTu.IndustryFinancial.AverageSalary,
                    Exempt = tTu.IndustryFinancial.Exempt,
                    isExemptTax = tTu.IndustryFinancial.isExemptTax,
                    MaxSalary = tTu.IndustryFinancial.MaxSalary,
                    MinSalary = tTu.IndustryFinancial.MinSalary
                });
            }

            return result;
        }

        private List<FinancialToIndustry> MapTaxToUTM(
            IndustryFinancialCreationDTO industryFinancialCreationDto, IndustryFinancial industryFinancial)
        {
            var result = new List<FinancialToIndustry>();
            foreach (var id in industryFinancialCreationDto.UtmId)
            {
                result.Add(new FinancialToIndustry() {UtmId = id});
            }

            return result;
        }
    }
}