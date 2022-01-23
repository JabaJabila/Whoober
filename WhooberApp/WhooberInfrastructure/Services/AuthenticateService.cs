using System;
using System.Linq;
using System.Security.Authentication;
using WhooberCore.Dto;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;

namespace WhooberInfrastructure.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly WhooberContext _context;

        public AuthenticateService(WhooberContext context)
        {
            _context = context;
        }

        public void ValidateLoginDto(AccountInfoDto account)
        {
            if (!IsPhoneNumberValid(account.PhoneNumber))
                throw new AuthenticationException($"Invalid phone number: {account.PhoneNumber}");
        }

        public void ValidateRegisterDto(AccountInfoDto account)
        {
            if (!IsPhoneNumberValid(account.PhoneNumber))
                throw new AuthenticationException("Invalid phone number");
            if (_context.Accounts.Any(x =>
                x.PhoneNumber == account.PhoneNumber
                && x.Role == account.Role))
                throw new AuthenticationException("There is another account with such credentials");
        }

        public Guid Login(AccountInfoDto account)
        {
            AccountInfoDto existingAccount = _context.Accounts.FirstOrDefault(x =>
                x.PhoneNumber == account.PhoneNumber
                && x.Password == account.Password
                && x.Role == account.Role);
            if (existingAccount is null)
                throw new AuthenticationException("Incorrect account credentials");

            return existingAccount.ClientIdInDb;
        }

        public Guid Register(AccountInfoDto account)
        {
            if (_context.Accounts.Any(x =>
                x.PhoneNumber == account.PhoneNumber
                && x.Role == account.Role))
                throw new AuthenticationException("There is another account with such credentials");

            var clientId = Guid.NewGuid();
            account.ClientIdInDb = clientId;
            _context.Accounts.Add(account);
            _context.SaveChanges();

            return clientId;
        }

        private bool IsPhoneNumberValid(string number)
        {
            return true;
        }
    }
}