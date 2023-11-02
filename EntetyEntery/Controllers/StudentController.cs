using EntetyEntery.DataAccess;
using EntetyEntery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntetyEntery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ApplicationDbContext _context;
        public StudentController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            try
            {
                var value = _context.Students.AsNoTracking().ToListAsync();
                if(value is not null)
                {
                    return Ok(value);
                }
                return NotFound("Ma'lumot topilmadi");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost]
        public async ValueTask<IActionResult> AdUser(Students student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpPatch]
        public async ValueTask<IActionResult> UpdateUser(int id,string name )
        {
            var value = await _context.Students.FirstOrDefaultAsync(x=>x.Id==id);
            if(value!=null)
            {
                value.Name= name;
                 _context.Update(value);
                await _context.SaveChangesAsync();
            }
            return Ok(value);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(user!=null)
            {
                _context.Students.Remove(user);
                await _context.SaveChangesAsync();
            }
            return Ok(user);
        }
    }
}
