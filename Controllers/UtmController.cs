using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticsApp.Data;
using StatisticsApp.DTO;
using StatisticsApp.Entity;

namespace StatisticsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtmController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UtmController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllUtms")]
        public async Task<ActionResult<List<UtmDTO>>> Get()
        {
            var utms = await _context.Set<UTM>().AsNoTracking().ToListAsync();
            var result = _mapper.Map<List<UtmDTO>>(utms);
            return result;
        }

        [HttpGet("id", Name = "getUtm")]
        public async Task<ActionResult<UtmDetailDTO>> Get(int id)
        {
            var utm = await _context.Utms
                .Include(u => u.FinancialToIndustries)
                .ThenInclude(u => u.IndustryFinancial)
                .Include(u => u.OficeToUtm)
                .ThenInclude(u => u.CentralOfice)
                .FirstOrDefaultAsync(u => u.Id == id);

            return _mapper.Map<UtmDetailDTO>(utm);

            /*var utm = _context.Utms.FirstOrDefault(u => u.Id == id);
            if (utm == null)
            {
                return NotFound();
            }

            return Ok(utm);*/
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UtmCreationDtO utmCreationDtO)
        {
            var utm = _mapper.Map<UTM>(utmCreationDtO);
            _context.Add(utm);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("getUtm", new {id = utm.Id}, utm);
        }

        [HttpPut("{id}", Name = "putUtm")]
        public async Task<ActionResult> Put(int id, [FromBody] UtmCreationDtO utmCreationDtO)
        {
            var utm = _mapper.Map<UTM>(utmCreationDtO);
            utm.Id = id;
            _context.Entry(utm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}", Name = "Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var utm = _context.Utms.FirstOrDefault(u => u.Id == id);
            _context.Remove(utm);
            _context.SaveChangesAsync();
            return new CreatedAtRouteResult("getUtm", new {id = utm.Id}, utm);
        }
    }
}