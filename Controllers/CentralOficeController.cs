using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StatisticsApp.Data;
using StatisticsApp.DTO;
using StatisticsApp.Entity;

namespace StatisticsApp.Controllers
{
    [Route("api/CentralOficeController")]
    [ApiController]
    public class CentralOficeController : CustomBaseController
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CentralOficeController(ApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            {
            }
        }

        [HttpGet(Name = "GeAllCentralOfice")]
        public async Task<ActionResult<List<CentralOficeDTO>>> Get()
        {
            return await Get<CentralOfice, CentralOficeDTO>();
        }

        [HttpGet("id", Name = "GetCentralOficeById")]
        public async Task<ActionResult<CentralOficeDTO>> Get(int id)
        {
            return await Get<CentralOfice, CentralOficeDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CentralOficeCreationDTO centralOficeCreationDto)
        {
            var centeralOfice = _mapper.Map<CentralOfice>(centralOficeCreationDto);
            _context.Add(centeralOfice);
            await _context.SaveChangesAsync();
            var centeralOficeDto = _mapper.Map<CentralOficeDTO>(centeralOfice);
            return new CreatedAtRouteResult("GetCentralOficeById", new {id = centeralOficeDto.Id}, centeralOficeDto);
        }

        [HttpPut("id", Name = "putCentralOficial")]
        public async Task<ActionResult> put(int id, [FromBody] CentralOficeCreationDTO centralOficeCreationDto)
        {
            return await Put<CentralOficeCreationDTO, CentralOfice>(id, centralOficeCreationDto);
        }

        [HttpDelete("{id}", Name = "deleteCentralOfice")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<CentralOfice>(id);
        }
    }
}