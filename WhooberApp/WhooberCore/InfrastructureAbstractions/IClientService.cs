using System;
using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IClientService
    {
        Passenger RegisterPassenger(Passenger passenger);
        IReadOnlyCollection<Trip> GetTripHistory(Guid id);
        Passenger FindPassengerById(Guid id);
    }
}