using System;
using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IClientService
    {
        void RegisterPassenger(Passenger passenger);
        void RegisterPassenger(Passenger passenger, AccountInfoDto accountInfoDto);
        IReadOnlyCollection<Trip> GetTripHistory(Passenger passenger);
        Passenger FindPassengerById(Guid id);
    }
}