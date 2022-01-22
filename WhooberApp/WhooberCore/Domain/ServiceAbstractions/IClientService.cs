using System.Collections.Generic;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IClientService
    {
        Passenger RegisterPassenger(Passenger passenger);
        IReadOnlyCollection<Trip> GetTripHistory(Passenger passenger);
    }
}