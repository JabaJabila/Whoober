using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WhooberCore.InfrastructureAbstractions;

namespace Whoober_WebApplication.Controllers
{
    public class DriverController : Controller
    {
        private readonly ILogger<DriverController> _logger;
        private readonly IDriverService _driverService;

        public DriverController(ILogger<DriverController> logger, IDriverService driverService)
        {
            _logger = logger;
            _driverService = driverService;
        }

        [Authorize(Policy = "Driver")]
        public IActionResult Index()
        {
            return View();
        }
    }
}