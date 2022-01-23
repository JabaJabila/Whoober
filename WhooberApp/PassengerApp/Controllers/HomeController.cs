using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PassengerApp.Models;
using WhooberCore.Domain.Entities;
using WhooberCore.InfrastructureAbstractions;

namespace PassengerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientService _service;

        public HomeController(ILogger<HomeController> logger, IClientService service)
        {
            _logger = logger;
            _service = service;
        }

        [Authorize]
        public IActionResult Index()
        {
            var passengerId = Guid.Parse(User.Identity!.Name!);
            Trip trip = _service.GetActiveTrip(passengerId);
            ViewData["trip"] = trip;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}