

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentdb.Data;
using studentdb.Model;

namespace studentdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _dbContext;
        
        public StudentController(StudentContext dbContext)
        { 
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllStudents() 
        {
            var student = await _dbContext.Students.ToListAsync();
            return Ok(student);
        }
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetStudent(int id)
        { 
            var student = await _dbContext.Students.FindAsync(id); 
            if (student == null)
            {
                return NotFound();
            } 
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        { 
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync(); 
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(int id, Student student)
        {
            var existingStudent = await _dbContext.Students.FindAsync(id); 
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.FirstName = student.FirstName; 
            existingStudent.LastName = student.LastName;
            existingStudent.Age = student.Age;
            existingStudent.BloodGroup = student.BloodGroup;
            await _dbContext.SaveChangesAsync();
            return Ok(existingStudent);
        }

            [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteStudent(int id)
        { 
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound(); 
            }
            _dbContext.Students.Remove(student); 
            await _dbContext.SaveChangesAsync();
            return Ok(); }
    }
}
