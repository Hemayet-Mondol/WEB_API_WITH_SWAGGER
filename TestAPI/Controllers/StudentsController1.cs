using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController1 : ControllerBase
    {
        private readonly StudentDbContext _context;
        public StudentsController1(StudentDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _context.StudentTable.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var st=await _context.StudentTable.FindAsync(id);
             if (st == null)
            {
              return  NotFound();
            }
            else
            {
              return  Ok(st);
            }
        

        }
        [HttpPost()]
        public async Task<IActionResult> Create(Student student)
        {
            await _context.StudentTable.AddAsync(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = student.Id },student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student) 
        {
            if (id != student.Id) { return BadRequest(); }
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete (int id)
        {
            var Stdel = await _context.StudentTable.FindAsync(id);
            if (Stdel == null) { return NotFound(); }
            _context.StudentTable.Remove(Stdel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
