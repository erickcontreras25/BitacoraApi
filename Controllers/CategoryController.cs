using System.Threading.Tasks;
using Bitacora.API.Data;
using Bitacora.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bitacora.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;    
        }     

        public async Task<IActionResult> GetAll(){
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(long id){
            var categories = await _context.Categories.FirstOrDefaultAsync(q => q.Id == id);

            if(categories == null){
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Category item)
        {
            _context.Categories.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new {id = item.Id}, item);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var categories = await _context.Categories.FindAsync(id);

            if(categories == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Category item)
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