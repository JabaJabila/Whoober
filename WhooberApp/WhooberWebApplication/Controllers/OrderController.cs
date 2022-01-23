using Microsoft.AspNetCore.Mvc;
using WhooberCore.Domain.Entities;
using WhooberCore.InfrastructureAbstractions;

namespace Whoober_WebApplication.Controllers
{
    [ApiController]
    [Route("/driversController")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("get-cost")]
        public decimal RequestCost([FromBody] OrderRequest request)
        {
            return _orderService.RequestTripCost(request);
        }

        [HttpPost("approve-order")]
        public IActionResult ApproveOrderRequest([FromBody] Order order)
        {
            return Ok(_orderService.ApproveOrder(order));
        }
    }
}