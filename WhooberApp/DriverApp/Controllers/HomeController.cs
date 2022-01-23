using System;
using System.Diagnostics;
using System.Security.Authentication;
using DriverApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WhooberCore.InfrastructureAbstractions;

namespace DriverApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDriverService _driverService;

        public HomeController(ILogger<HomeController> logger, IDriverService driverService)
        {
            _logger = logger;
            _driverService = driverService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [Authorize]
        public IActionResult StartWorking()
        {
            if (!(User is {Identity: {Name: {}}}))
            {
                throw new AuthenticationException();
            }

            var driverId = Guid.Parse(User.Identity.Name);
            _driverService.SetDriverStateToWaiting(driverId);
            return Ok(true);
        }
        
        [Authorize]
        public IActionResult StopWorking()
        {
            if (!(User is {Identity: {Name: {}}}))
            {
                throw new AuthenticationException();
            }

            var driverId = Guid.Parse(User.Identity.Name);
            _driverService.SetDriverStateToInactive(driverId);
            return Ok(true);
        }
        
        [Authorize]
        public IActionResult AcceptOrder()
        {
            if (!(User is {Identity: {Name: {}}}))
            {
                throw new AuthenticationException();
            }

            var driverId = Guid.Parse(User.Identity.Name);
            _driverService.SetDriverStateToWaiting(driverId);
            return Ok(true);
        }
    }
}