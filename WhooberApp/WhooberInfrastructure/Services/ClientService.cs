using System;
using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;

namespace WhooberInfrastructure.Services
{
    public class ClientService : IClientService
    {
        private WhooberContext _whooberContext;
        public ClientService(WhooberContext whooberContext)
        {
            _whooberContext = whooberContext;
        }
        public void RegisterPassenger(Passenger passenger)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<Trip> GetTripHistory(Passenger passenger)
        {
            throw new System.NotImplementedException();
        }
        public Passenger FindPassengerById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}