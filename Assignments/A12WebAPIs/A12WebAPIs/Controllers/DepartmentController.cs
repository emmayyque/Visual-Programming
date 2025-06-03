using A12WebAPIs.Models.Entities;
using A12WebAPIs.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace A12WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDataRepository<Department> repo;

        public DepartmentController(IDataRepository<Department> _repo)
        {
            repo = _repo;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var deptFromDb = repo.GetById(id);
            
            if (deptFromDb == null)
            {
                return NotFound("Department Not Found");
            }

            return Ok(deptFromDb);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest("Department Data is empty");
            }
            repo.Add(department);
            return CreatedAtRoute(
                    "Get",
                    new { id = department.Id },
                    department
                );
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Department department)
        {
            Department deptFromDb = repo.GetById(id);
            if (deptFromDb == null)
            {
                return NotFound("Department Not Found");
            }
            if (department == null)
            {
                return BadRequest("Department Data is empty");
            }
            repo.Update(deptFromDb, department);
            return Ok(deptFromDb);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Department deptFromDb = repo.GetById(id);
            if (deptFromDb == null)
            {
                return NotFound("Department Not Found");
            }
            repo.Delete(deptFromDb);
            return NoContent();
        }
    }
}
