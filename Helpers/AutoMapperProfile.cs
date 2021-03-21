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
                    opt => opt.MapFrom(MapTaxToUTM))
                .ForMember(x => x.CentralOfice,
                    opt => opt.MapFrom(MapCentralToUTM))
                ;
            //tax map
            CreateMap<TaxRate, TaxDTO>().ReverseMap();
            CreateMap<TaxtCreationDTO, TaxRate>();
            // industry financial
            CreateMap<IndustryFinancial, IndustryFinancialDTO>().ReverseMap();
            CreateMap<IndustryFinancialCreationDTO, IndustryFinancial>().ForMember(x => x.FinancialToIndustries
                , opt => opt.MapFrom(MapTaxToUTM));
            // CentralOfice
            CreateMap<CentralOfice, CentralOficeDTO>().ReverseMap();
            CreateMap<CentralOficeCreationDTO, CentralOfice>().ForMember(x => x.OficeToUtm
                , opt => opt.MapFrom(MapCentralToUTM)
            );
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

        // map central to utm 
        private List<CentralOficeDTO> MapCentralToUTM(UTM utm, UtmDetailDTO utmDetailDto)
        {
            var result = new List<CentralOficeDTO>();
            foreach (var cTu in utm.OficeToUtm)
            {
                result.Add(new CentralOficeDTO()

                {
                    Id = cTu.CentralOfice.Id,
                    City = cTu.CentralOfice.City,
                    Latitude = cTu.CentralOfice.Latitude,
                    Lngitude = cTu.CentralOfice.Lngitude,
                    Name = cTu.CentralOfice.Name,
                    PostalCode = cTu.CentralOfice.PostalCode
                });
            }

            return result;
        }

        private List<OficeToUtm> MapCentralToUTM(
            CentralOficeCreationDTO centralOficeCreationDto, CentralOfice centralOfice)
        {
            var result = new List<OficeToUtm>();
            foreach (var id in centralOficeCreationDto.UtmId)
            {
                result.Add(new OficeToUtm() {UtmId = id});
            }

            return result;
        }
    }
}