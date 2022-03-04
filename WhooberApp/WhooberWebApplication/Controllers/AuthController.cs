// using System.Collections.Generic;
// using System.Security.Claims;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authentication.Cookies;
// using Microsoft.AspNetCore.Mvc;
// using Whoober_WebApplication.Authentication;
// using Whoober_WebApplication.Authentication.Services;
// using WhooberCore.Domain.Entities;
// using WhooberCore.Dto;
// using WhooberCore.InfrastructureAbstractions;
// using WhooberCore.Models;
//
// namespace Whoober_WebApplication.Controllers
// {
//     public class AuthController : Controller
//     {
//         private readonly IAuthenticateService _authenticateService;
//         private readonly IDriverService _driverService;
//         private readonly IClientService _clientService;
//         public AuthController(IAuthenticateService authenticateService, IClientService clientService, IDriverService driverService)
//         {
//             _authenticateService = authenticateService;
//             _clientService = clientService;
//             _driverService = driverService;
//         }
        //
        // [HttpGet]
        // public IActionResult Index()
        // {
        //     return RedirectToAction("Login");
        // }
        //
        // [HttpGet]
        // public IActionResult Login()
        // {
        //     return View();
        // }
        //
        // [HttpGet]
        // public IActionResult Register()
        // {
        //     return View();
        // }
        //
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> LoginClient(LoginModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         ViewData["errors"] = new List<string> {"Fill all fields"};
        //         return View("Login");
        //     }
        //
        //     AccountInfoDto accountInfoDto = await _authenticateService.LoginClient(model);
        //     if (accountInfoDto != null)
        //     {
        //         await Authenticate(model.PhoneNumber, Role.Client.Name);
        //
        //         return RedirectToAction("Index", "Passenger");
        //     }
        //
        //     // ModelState.AddModelError(string.Empty, "Incorrect login or password");
        //
        //     ViewData["errors"] = new List<string> {"Incorrect login or password"};
        //     return View("Login");
        // }
        //
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> LoginDriver(LoginModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         ViewData["errors"] = new List<string> {"Fill all fields"};
        //         return View("Login");
        //     }
        //
        //     AccountInfoDto accountInfoDto = await _authenticateService.LoginDriver(model);
        //     if (accountInfoDto != null)
        //     {
        //         await Authenticate(model.PhoneNumber, Role.Driver.Name);
        //         return RedirectToAction("Index", "Driver");
        //     }
        //
        //     // ModelState.AddModelError(string.Empty, "Incorrect login or password");
        //
        //     ViewData["errors"] = new List<string> {"Incorrect login or password"};
        //     return View("Login");
        // }
        //
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> RegisterClient(RegisterModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         ViewData["errors"] = new List<string> {"Fill all fields"};
        //         return View("Register");
        //     }
        //
        //     List<string> errors = _authenticateService.ValidateRegisterModel(model);
        //     if (errors.Count == 0)
        //     {
        //         var passenger = new Passenger(model.Name, model.PhoneNumber);
        //         var accountDto = new AccountInfoDto()
        //         {
        //             PhoneNumber = model.PhoneNumber,
        //             Password = model.Password,
        //         };
        //
        //         _clientService.RegisterPassenger(passenger, accountDto);
        //         await Authenticate(model.PhoneNumber, Role.Client.Name);
        //
        //         return RedirectToAction("Index", "Home");
        //     }
        //
        //     foreach (string error in errors)
        //     {
        //         ModelState.AddModelError(string.Empty, error);
        //     }
        //
        //     ViewData["errors"] = errors;
        //     return View("Register");
        // }
        //
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> RegisterDriver(RegisterModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         ViewData["errors"] = new List<string> {"Fill all fields"};
        //         return View("Register");
        //     }
        //
        //     List<string> errors = _authenticateService.ValidateRegisterModel(model);
        //     if (errors.Count == 0)
        //     {
        //         var driver = new Driver(model.Name, model.PhoneNumber);
        //         var accountDto = new AccountInfoDto()
        //         {
        //             PhoneNumber = model.PhoneNumber,
        //             Password = model.Password,
        //         };
        //         _driverService.RegisterDriver(driver, accountDto);
        //         await Authenticate(model.PhoneNumber, Role.Driver.Name);
        //
        //         return RedirectToAction("Index", "Driver");
        //     }
        //
        //     foreach (string error in errors)
        //     {
        //         ModelState.AddModelError(string.Empty, error);
        //     }
        //
        //     ViewData["errors"] = errors;
        //     return View("Register");
        // }
        //
        // public async Task<IActionResult> Logout()
        // {
        //     await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //     return RedirectToAction("Index", "Home");
        // }
        //
        // private async Task Authenticate(string identifier, string roleName)
        // {
        //     var claims = new List<Claim>
        //     {
        //         new Claim(roleName, identifier),
        //     };
        //
        //     var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //
        //     await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
//         // }
//     }
// }