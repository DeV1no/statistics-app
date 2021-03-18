using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StatisticsApp.Data;
using StatisticsApp.DTO;
using StatisticsApp.Entity;

namespace StatisticsApp.Controllers
{
    [Route("api/IndustryFinancial")]
    [ApiController]
    public class IndustryFinancialController : CustomBaseController
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public IndustryFinancialController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            {
            }
        }

        [HttpGet(Name = "GeAllIndustryFinancials")]
        public async Task<ActionResult<List<IndustryFinancialDTO>>> Get()
        {
            return await Get<IndustryFinancial, IndustryFinancialDTO>();
        }

        [HttpGet("id", Name = "getIndustryFinancialById")]
        public async Task<ActionResult<IndustryFinancialDTO>> Get(int id)
        {
            return await Get<IndustryFinancial, IndustryFinancialDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] IndustryFinancialCreationDTO industryFinancialCreationDto)
        {
            var taxRate = _context.TaxRates.FirstOrDefault(t => t.Id == 1).TaxRateCount;
            industryFinancialCreationDto.AverageSalary =
                (industryFinancialCreationDto.MaxSalary + industryFinancialCreationDto.MinSalary) / 2;
            industryFinancialCreationDto.Exempt =
                industryFinancialCreationDto.AverageSalary * taxRate / 100;
            /*TaxCounter(industryFinancialCreationDto.AverageSalary, industryFinancialCreationDto.MaxSalary,
                industryFinancialCreationDto.MinSalary, industryFinancialCreationDto.Exempt, taxRate,
                industryFinancialCreationDto.isExemptTax);*/
            var ifc = _mapper.Map<IndustryFinancial>(industryFinancialCreationDto);

            _context.Add(ifc);
            await _context.SaveChangesAsync();
            var ifcDto = _mapper.Map<IndustryFinancialDTO>(ifc);
            return new CreatedAtRouteResult("getIndustryFinancialById", new {id = ifcDto.Id}, ifcDto);
        }

        [HttpPut("id", Name = "putIndustryFinancialById")]
        public async Task<ActionResult> Put(int id,
            [FromBody] IndustryFinancialCreationDTO industryFinancialCreationDto)
        {
            return await Put<IndustryFinancialCreationDTO, IndustryFinancial>(id, industryFinancialCreationDto);
        }

        [HttpDelete("{id}", Name = "deleteIndustryFinancisal")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<IndustryFinancial>(id);
        }

        //Average And Tax Counter
        /*private void TaxCounter(double AS, double maxS, double minS, double tax, double taxR, bool isExemptTax)
        {
            AS = maxS + minS / 2;
            if (isExemptTax)
                tax = 0;
            else
                tax = AS * taxR / 2;
        }*/
    }
}