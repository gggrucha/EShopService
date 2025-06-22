using Microsoft.AspNetCore.Mvc;
using Product.Application.Commands;
using Product.Application.Handlers;
using Product.Application.Interfaces;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductCommandHandler _handler;
        private readonly IProductRepository _repository;

        public ProductController(CreateProductCommandHandler handler, IProductRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductCommand command)
        {
            _handler.Handle(command);
            return Ok("Product created");
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());
    }
}