using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.InfrastructureAbstractions;
using WhooberCore.Models;

namespace PassengerApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IClientService _clientService;
        public AuthController(IAuthenticateService authenticateService, IClientService clientService)
        {
            _authenticateService = authenticateService;
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["error"] = "Fill all fields";
                return View();
            }

            var account = new AccountInfoDto
            {
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Role = Role.Passenger,
            };

            try
            {
                _authenticateService.ValidateLoginDto(account);
                Guid passengerId = _authenticateService.Login(account);

                await Authenticate(passengerId);
                return RedirectToAction("Index", "Home");
            }
            catch (AuthenticationException e)
            {
                ViewData["error"] = e.Message;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["error"] = "Fill all fields";
                return View();
            }

            var account = new AccountInfoDto()
            {
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Role = Role.Passenger,
            };

            try
            {
                _authenticateService.ValidateRegisterDto(account);
                Guid passengerId = _authenticateService.Register(account);
                var passenger = new Passenger(model.Name, model.PhoneNumber)
                {
                    Id = passengerId,
                };
                _clientService.RegisterPassenger(passenger);
                
                await Authenticate(passengerId);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(Guid identifier)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, identifier.ToString()),
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}