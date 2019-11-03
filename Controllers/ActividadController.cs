using System.Threading.Tasks;
using Bitacora.API.Data;
using Bitacora.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bitacora.API.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class ActividadController : ControllerBase
    {
        private readonly DataContext _context;

        public ActividadController(DataContext context)
        {
            _context = context;    
        }  

        public async Task<IActionResult> GetAll(){
            var actividad = await _context.Actividad.ToListAsync();
            return Ok(actividad);
        }   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActividad(long id){
            var actividad = await _context.Actividad.FirstOrDefaultAsync(q => q.Id == id);

            if(actividad == null){
                return NotFound();
            }
            return Ok(actividad);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Actividad item)
        {
            _context.Actividad.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new {id = item.Id}, item);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var actividad = await _context.Actividad.FindAsync(id);

            if(actividad == null)
            {
                return NotFound();
            }

            _context.Actividad.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Actividad item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return NoContent();
        }


    }
}