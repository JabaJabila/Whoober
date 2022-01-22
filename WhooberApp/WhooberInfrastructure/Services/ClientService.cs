using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.InfrastructureAbstractions;

namespace WhooberInfrastructure.Services
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