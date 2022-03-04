using System;
using Microsoft.AspNetCore.Mvc;
using WhooberCore.Domain.Entities;
using WhooberCore.InfrastructureAbstractions;

namespace Whoober_WebApplication.Controllers
{
    [ApiController]
    [Route("/driversController")]
    public class PassengerController : Controller
    {
        private readonly IClientService _clientService;

        public PassengerController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("register-passenger")]
        public IActionResult RegisterPassenger([FromQuery] string name, [FromQuery] string number)
        {
            var passenger = new Passenger(name, number);
            return Ok(_clientService.RegisterPassenger(passenger));
        }

        [HttpGet("get-history")]
        public IActionResult GetTripHistory([FromQuery] Guid id)
        {
            return Ok(_clientService.GetTripHistory(id));
        }

        [HttpGet("find-passenger")]
        public IActionResult FindPassenger([FromQuery] Guid id)
        {
            return Ok(_clientService.FindPassengerById(id));
        }
    }
}