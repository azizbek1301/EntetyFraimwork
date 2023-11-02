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
        public IActionResult GetAll()
        {
            var value = _context.Students.ToList();
            return Ok(value);
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
    }
}
