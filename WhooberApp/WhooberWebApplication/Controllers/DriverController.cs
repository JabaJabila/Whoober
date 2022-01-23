using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Whoober_WebApplication.Controllers
{
    public class DriverController : Controller
    {
        private readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}