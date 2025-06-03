using Microsoft.AspNetCore.Mvc;
using WebAPI_Exam_.Models.Entities;
using WebAPI_Exam_.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Exam_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IDataRepository<Bike> repo;

        public BikeController(IDataRepository<Bike> _repo)
        {
            repo = _repo;
        }

        // GET: api/<BikeController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        // GET api/<BikeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bikeFromDb = repo.GetById(id);
            
            if (bikeFromDb == null)
            {
                return NotFound("Bike not found!!!");
            }

            return Ok(bikeFromDb);
        }

        // POST api/<BikeController>
        [HttpPost]
        public IActionResult Post([FromBody] Bike bike)
        {
            if (bike == null)
            {
                return BadRequest("Bike Data is empty");
            }

            repo.Add(bike);
            return CreatedAtRoute(
                    "Get",
                    new { id = bike.Id },
                    bike
                );
        }

        // PUT api/<BikeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Bike bike)
        {
            var bikeFromDb = repo.GetById(id);

            if (bikeFromDb == null)
            {
                return NotFound("Bike not found!!!");
            }

            if (bike == null)
            {
                return BadRequest("Bike Data is empty");
            }

            repo.Update(bikeFromDb, bike);
            return Ok(bikeFromDb);
        }

        // DELETE api/<BikeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bikeFromDb = repo.GetById(id);

            if (bikeFromDb == null)
            {
                return NotFound("Bike not found!!!");
            }

            repo.Delete(bikeFromDb);
            return NoContent();
        }
    }
}
