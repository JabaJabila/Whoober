using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.InfrastructureAbstractions;
using WhooberCore.Models;
using WhooberInfrastructure.Data;

namespace Whoober_WebApplication.Authentification.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private WhooberContext _context;
        public AuthorizeService(WhooberContext context)
        {
            _context = context;
        }

        public Task<AccountInfoDto> LoginClient(LoginModel loginModel)
        {
            return _context.Accounts.FirstOrDefaultAsync(x =>
                x.PhoneNumber == loginModel.PhoneNumber && x.Password == loginModel.Password);
        }

        public Task<AccountInfoDto> LoginDriver(LoginModel loginModel)
        {
            return _context.Accounts.FirstOrDefaultAsync(x =>
                x.PhoneNumber == loginModel.PhoneNumber && x.Password == loginModel.Password);
        }

        public bool ClientPhoneNumberIsValid(string number)
        {
            // TODO roles
            return _context.Accounts.All(x => x.PhoneNumber != number);
        }

        public bool DriverPhoneNumberIsValid(string number)
        {
            return _context.Accounts.All(x => x.PhoneNumber != number);
        }
    }
}