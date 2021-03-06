using System.Collections.Generic;
using System.Threading.Tasks;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.Models;

namespace Whoober_WebApplication.Authentication.Services
{
    public interface IAuthenticateService
    {
        Task<AccountInfoDto> LoginClient(LoginModel loginModel);
        Task<Passenger> RegisterClient(RegisterModel registerModel);
        Task<AccountInfoDto> LoginDriver(LoginModel loginModel);
        Task<Driver> RegisterDriver(RegisterModel registerModel);

        List<string> ValidateLoginModel(LoginModel loginModel);
        List<string> ValidateRegisterModel(RegisterModel registerModel);
    }
}