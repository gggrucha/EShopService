using Microsoft.AspNetCore.Mvc;
using Order.Domain.Commands;
using Order.Domain.Entities;
using Order.Infrastructure.Repositories;
using OrderItem = Order.Domain.Entities.OrderItem;

namespace Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderCommand command)
        {
            var items = command.Items.Select(i => new OrderItem { ProductId = i.ProductId, Quantity = i.Quantity }).ToList();
            var order = new CustomerOrder(command.CustomerId, items);
            _repository.Save(order);
            return Ok(order);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(Guid id)
        {
            var order = _repository.GetById(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(Guid id, [FromBody] string newStatus)
        {
            _repository.UpdateStatus(id, newStatus);
            return Ok($"CustomerOrder {id} status updated to {newStatus}");
        }

        [HttpDelete("{id}")]
        public IActionResult CancelOrder(Guid id)
        {
            _repository.Delete(id);
            return Ok($"CustomerOrder {id} cancelled");
        }
    }
}