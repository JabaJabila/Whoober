using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.InfrastructureAbstractions;
using WhooberCore.Models;

namespace Whoober_WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticateService _authenticateService;
        private IDriverService _driverService;
        private IClientService _clientService;
        public AccountController(IAuthenticateService authenticateService, IClientService clientService, IDriverService driverService)
        {
            _authenticateService = authenticateService;
            _clientService = clientService;
            _driverService = driverService;
        }

        [HttpGet]
        public IActionResult LoginClient()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginDriver()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginClient(LoginModel model)
        {
            if (!ModelState.IsValid) return View(model);
            ClientDto clientDto = await _authenticateService.LoginClient(model);
            if (clientDto != null)
            {
                await Authenticate(model.PhoneNumber);
 
                return RedirectToAction("Index", "Passenger");
            }

            ModelState.AddModelError("", "Invalid login/password");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginDriver(LoginModel model)
        {
            if (!ModelState.IsValid) return View(model);
            ClientDto clientDto = await _authenticateService.LoginDriver(model);
            if (clientDto != null)
            {
                await Authenticate(model.PhoneNumber);
 
                return RedirectToAction("Index", "Driver");
            }

            ModelState.AddModelError("", "Invalid login/password");

            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterClient()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterDriver()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterClient(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (_authenticateService.ClientPhoneNumberIsValid(model.PhoneNumber))
            {
                var client = await _authenticateService.RegisterClient(model);
                _clientService.RegisterPassenger(client);
                await Authenticate(model.PhoneNumber);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Choose another login");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterDriver(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (_authenticateService.DriverPhoneNumberIsValid(model.PhoneNumber))
            {
                Driver driver = await _authenticateService.RegisterDriver(model);
                _driverService.RegisterDriver(driver);
                await Authenticate(model.PhoneNumber);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Choose another login");

            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}