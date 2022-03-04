using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.InfrastructureAbstractions;

namespace PassengerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;
        public OrderController(IOrderService orderService, IClientService clientService)
        {
            _orderService = orderService;
            _clientService = clientService;
        }

        [HttpPost]
        [Authorize]
        public Dictionary<CarLevel, decimal> Get(Route route)
        {
            Passenger passenger = _clientService.FindPassengerById(Guid.Parse(User.Identity!.Name!));
            var priceList = new Dictionary<CarLevel, decimal>();
            foreach (CarLevel carLevel in Enum.GetValues(typeof(CarLevel)))
            {
                var orderRequest = new OrderRequest(passenger, route, carLevel);
                _orderService.RequestTripCost(orderRequest);
                priceList[carLevel] = _orderService.RequestTripCost(orderRequest);
            }
            
            return priceList;
        }
    }
}