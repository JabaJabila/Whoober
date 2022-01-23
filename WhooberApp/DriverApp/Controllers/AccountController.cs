using System;
using System.Security.Authentication;
using DriverApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WhooberCore.Domain.Entities;
using WhooberCore.InfrastructureAbstractions;

namespace DriverApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IDriverService _driverService;
        public AccountController(ILogger<AccountController> logger, IDriverService driverService)
        {
            _logger = logger;
            _driverService = driverService;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            if (User.Identity?.Name == null)
            {
                throw new AuthenticationException();
            }

            Driver driver = _driverService.FindDriverById(Guid.Parse(User.Identity.Name));
            var model = new DriverModel(driver);
            return View(model);
        }
    }
}