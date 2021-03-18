using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticsApp.Data;
using StatisticsApp.DTO;
using StatisticsApp.Entity;

namespace StatisticsApp.Controllers
{
    [Route("api/TaxRate")]
    [ApiController]
    public class TaxtRateController : CustomBaseController
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TaxtRateController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetTax")]
        public async Task<ActionResult<List<TaxDTO>>> Get()
        {
            return await Get<TaxRate, TaxDTO>();
        }

        [HttpGet("id", Name = "getTaxById")]
        public async Task<ActionResult<TaxDTO>> Get(int id)
        {
            return await Get<TaxRate, TaxDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TaxtCreationDTO taxtCreationDto)
        {
            var tax = _mapper.Map<UTM>(taxtCreationDto);
            _context.Add(tax);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("getTaxById", new {id = tax.Id}, tax);
        }

        [HttpPut("{id}", Name = "putTax")]
        public async Task<ActionResult> Put(int id, [FromBody] TaxtCreationDTO taxtCreationDto)
        {
            var tax = _mapper.Map<TaxRate>(taxtCreationDto);
            tax.Id = id;
            _context.Entry(tax).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}", Name = "deleteTax")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<TaxRate>(id);
        }
    }
}