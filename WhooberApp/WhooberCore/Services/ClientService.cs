using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class ClientService : IClientService
    {
        public void RegisterPassenger(Passenger passenger)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<Trip> GetTripHistory(Passenger passenger)
        {
            throw new System.NotImplementedException();
        }
    }
}