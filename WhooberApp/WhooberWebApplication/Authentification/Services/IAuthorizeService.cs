using System.Threading.Tasks;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.Models;

namespace Whoober_WebApplication.Authentification.Services
{
    public interface IAuthorizeService
    {
        Task<AccountInfoDto> LoginClient(LoginModel loginModel);
        Task<AccountInfoDto> LoginDriver(LoginModel loginModel);
        bool ClientPhoneNumberIsValid(string number);
        bool DriverPhoneNumberIsValid(string number);
    }
}