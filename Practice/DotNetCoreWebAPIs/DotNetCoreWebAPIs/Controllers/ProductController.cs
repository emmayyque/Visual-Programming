using DotNetCoreWebAPIs.Models.Entities;
using DotNetCoreWebAPIs.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataRepository<Product> repo;

        public ProductController(IDataRepository<Product> _repo)
        {
            repo = _repo;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var productFromDb = repo.GetById(id);

            if (productFromDb == null)
            {
                return NotFound("Product not found"); 
            }

            return Ok(productFromDb);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product Data is empty");
            }

            repo.Add(product);

            return CreatedAtRoute(
                    "Get",
                    new { id = product.Id },
                    product
                );
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            Product productFromDb = repo.GetById(id);
            if (productFromDb == null)
            {
                return NotFound("Product not found !!");
            }
            
            if (product == null)
            {
                return BadRequest("Product Data is empty");
            }

            repo.Update(productFromDb, product);
            return Ok(productFromDb);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product productFromDb = repo.GetById(id);
            if (productFromDb == null)
            {
                return NotFound("Product not found !!");
            }

            repo.Delete(productFromDb);
            return NoContent();
        }
    }
}
