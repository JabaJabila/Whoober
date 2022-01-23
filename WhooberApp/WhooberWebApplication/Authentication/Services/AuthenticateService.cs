using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.InfrastructureAbstractions;
using WhooberCore.Models;
using WhooberInfrastructure.Data;

namespace Whoober_WebApplication.Authentication.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private WhooberContext _context;
        public AuthenticateService(WhooberContext context)
        {
            _context = context;
        }

        public Task<ClientDto> LoginClient(LoginModel loginModel)
        {
            return _context.Accounts.FirstOrDefaultAsync(x =>
                x.PhoneNumber == loginModel.PhoneNumber && x.Password == loginModel.Password);
        }

        public async Task<Passenger> RegisterClient(RegisterModel registerModel)
        {
            var passenger = new Passenger(registerModel.Name, registerModel.PhoneNumber)
            {
                Id = Guid.NewGuid(),
            };
            var clientDto = new ClientDto()
            {
                ClientIdInDb = passenger.Id,
                PhoneNumber = registerModel.PhoneNumber,
                Password = registerModel.Password,
            };
            _context.Accounts.Add(clientDto);
            await _context.SaveChangesAsync();
            return passenger;
        }

        public Task<ClientDto> LoginDriver(LoginModel loginModel)
        {
            return _context.Accounts.FirstOrDefaultAsync(x =>
                x.PhoneNumber == loginModel.PhoneNumber && x.Password == loginModel.Password);
        }

        public async Task<Driver> RegisterDriver(RegisterModel registerModel)
        {
            var driver = new Driver(registerModel.Name, registerModel.PhoneNumber);
            var clientDto = new ClientDto()
            {
                ClientIdInDb = driver.Id,
                PhoneNumber = registerModel.PhoneNumber,
                Password = registerModel.Password,
            };

            _context.Accounts.Add(clientDto);
            await _context.SaveChangesAsync();
            return driver;
        }

        public bool ClientPhoneNumberIsValid(string number)
        {
            return _context.Accounts.All(x => x.PhoneNumber != number);
        }

        public bool DriverPhoneNumberIsValid(string number)
        {
            return _context.Accounts.All(x => x.PhoneNumber != number);
        }
    }
}