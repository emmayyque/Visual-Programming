using Microsoft.AspNetCore.Mvc;
using RestFullWebAPIs.Repository;
using RestFullWebAPIs.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestFullWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDataRepository<Student> repo;
        public StudentController(IDataRepository<Student> _repo)
        {
            repo = _repo;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student student = repo.GetById(id);

            if (student == null)
            {
                return NotFound("Student Not Found");
            }

            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student Data is empty");
            }

            repo.Add(student);
            return CreatedAtRoute(
                    "Get",
                    new { id = student.Id },
                    student
                );
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            Student dbStudent = repo.GetById(id); 
            if (dbStudent == null)
            {
                return NotFound("Student Not Found");
            }

            if (student == null)
            {
                return BadRequest("Student Data is empty");
            }

            repo.Update(dbStudent, student);
            return Ok(dbStudent);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student dbStudent = repo.GetById(id);
            if ( dbStudent == null )
            {
                return NotFound("Student Not Found");
            }

            repo.Delete(dbStudent);
            return NoContent();
        }
    }
}
