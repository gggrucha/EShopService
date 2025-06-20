
using Microsoft.AspNetCore.Mvc;
using Order.Application.CommandHandlers;
using Order.Domain.Commands;

namespace Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly CreateOrderCommandHandler _handler;

        public OrderController(CreateOrderCommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderCommand command)
        {
            _handler.Handle(command);
            return Ok("Order created.");
        }
    }
}
