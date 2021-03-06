using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.Models;
using WhooberInfrastructure.Data;

namespace Whoober_WebApplication.Authentication.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly WhooberContext _context;
        public AuthenticateService(WhooberContext context)
        {
            _context = context;
        }

        public Task<AccountInfoDto> LoginClient(LoginModel loginModel)
        {
            return _context.Accounts.FirstOrDefaultAsync(x =>
                x.PhoneNumber == loginModel.PhoneNumber && x.Password == loginModel.Password);
        }

        public async Task<Passenger> RegisterClient(RegisterModel registerModel)
        {
            var passenger = new Passenger(registerModel.Name, registerModel.PhoneNumber);
            var accountInfoDto = new AccountInfoDto()
            {
                ClientIdInDb = passenger.Id,
                PhoneNumber = registerModel.PhoneNumber,
                Password = registerModel.Password,
            };
            _context.Accounts.Add(accountInfoDto);
            await _context.SaveChangesAsync();
            return passenger;
        }

        public Task<AccountInfoDto> LoginDriver(LoginModel loginModel)
        {
            return _context.Accounts.FirstOrDefaultAsync(x =>
                x.PhoneNumber == loginModel.PhoneNumber && x.Password == loginModel.Password);
        }

        public async Task<Driver> RegisterDriver(RegisterModel registerModel)
        {
            var driver = new Driver(registerModel.Name, registerModel.PhoneNumber);
            var accountInfoDto = new AccountInfoDto()
            {
                ClientIdInDb = driver.Id,
                PhoneNumber = registerModel.PhoneNumber,
                Password = registerModel.Password,
            };

            _context.Accounts.Add(accountInfoDto);
            await _context.SaveChangesAsync();
            return driver;
        }

        public List<string> ValidateLoginModel(LoginModel loginModel)
        {
            var errors = new List<string>();
            if (!IsPhoneNumberValid(loginModel.PhoneNumber))
                errors.Add("Invalid phone number");

            return errors;
        }

        public List<string> ValidateRegisterModel(RegisterModel registerModel)
        {
            var errors = new List<string>();
            if (!IsPhoneNumberValid(registerModel.PhoneNumber))
                errors.Add("Invalid phone number");

            return errors;
        }

        private bool IsPhoneNumberValid(string number)
        {
            return _context.Accounts.All(x => x.PhoneNumber != number);
        }
    }
}