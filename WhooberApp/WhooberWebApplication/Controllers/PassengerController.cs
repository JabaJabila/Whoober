using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Whoober_WebApplication.Controllers
{
    public class PassengerController : Controller
    {
        private readonly ILogger<PassengerController> _logger;

        public PassengerController(ILogger<PassengerController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "Client")]
        public IActionResult Index()
        {
            return View();
        }
    }
}