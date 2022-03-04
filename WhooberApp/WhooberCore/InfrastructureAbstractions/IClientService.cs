using System;
using System.Collections.Generic;
using WhooberCore.Domain.Entities;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IClientService
    {
        Passenger RegisterPassenger(Passenger passenger);
        IReadOnlyCollection<Trip> GetTripHistory(Guid id);
        Passenger FindPassengerById(Guid id);
        Trip GetActiveTrip(Guid passengerId);
    }
}