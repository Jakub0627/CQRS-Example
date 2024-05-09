using CqrsExampleApi.Commands;
using CqrsExampleApi.Data;
using CqrsExampleApi.Entities;
using CqrsExampleApi.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CqrsExampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            var command = new CreateProductCommand(_context);
            command.Execute(product);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var query = new GetProductQuery(_context);
            var result = query.Execute(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
