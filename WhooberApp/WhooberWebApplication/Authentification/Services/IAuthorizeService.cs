using System.Threading.Tasks;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.Models;

namespace Whoober_WebApplication.Authentification.Services
{
    public interface IAuthorizeService
    {
        Task<ClientDto> LoginClient(LoginModel loginModel);
        Task<Passenger> RegisterClient(RegisterModel registerModel);

        Task<ClientDto> LoginDriver(LoginModel loginModel);
        Task<Driver> RegisterDriver(RegisterModel registerModel);
        bool ClientPhoneNumberIsValid(string number);
        bool DriverPhoneNumberIsValid(string number);
    }
}