using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatisticsApp.Data;

namespace StatisticsApp.Controllers
{
   public class CustomBaseController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CustomBaseController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected async Task<List<TDTO>> Get<TEntity, TDTO>() where TEntity : class
        {
            var entities = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            var dtos = _mapper.Map<List<TDTO>>(entities);
            return dtos;
        }

        /*protected async Task<List<TDTO>> Get<TEntity, TDTO>(PaginationDTO paginationDto) where TEntity : class
        {
            var queryable = _context.Set<TEntity>().AsNoTracking().AsQueryable();
            await HttpContext.InsertPaginationParametesInResponse(queryable, paginationDto.RecordsPerPage);
            var entities = await queryable.Paginate(paginationDto).ToListAsync();
            return _mapper.Map<List<TDTO>>(entities);
        }*/

        protected async Task<ActionResult<TDTO>> Get<TEntity, TDTO>(int id) where TEntity : class, IId
        {
            var entity = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return _mapper.Map<TDTO>(entity);
        }

        

        protected async Task<ActionResult> Put<TCreation, TEntity>(int id, TCreation creation)
            where TEntity : class, IId
        {
            var entity= _mapper.Map<TEntity>(creation);
            entity.Id = id;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        protected async Task<ActionResult> Delete<TEntity>(int id) where TEntity : class, IId,new()
        {
            var exist = await _context.Set<TEntity>().AnyAsync(g => g.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(new TEntity() {Id = id});
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }

        
    }
}
