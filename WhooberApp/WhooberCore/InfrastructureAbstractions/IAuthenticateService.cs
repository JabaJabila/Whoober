using System;
using WhooberCore.Dto;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IAuthenticateService
    {
        void ValidateLoginDto(AccountInfoDto account);
        void ValidateRegisterDto(AccountInfoDto account);

        Guid Login(AccountInfoDto account);
        Guid Register(AccountInfoDto account);
    }
}