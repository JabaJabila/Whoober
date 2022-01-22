using System;
using System.Collections.Generic;
using WhooberCore.Domain.Entities;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IClientService
    {
        void RegisterPassenger(Passenger passenger);
        IReadOnlyCollection<Trip> GetTripHistory(Passenger passenger);
        Passenger FindPassengerById(Guid id);
    }
}