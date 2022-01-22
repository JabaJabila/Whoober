using System;
using System.Collections.Generic;
using System.Linq;
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
            if (_whooberContext.Passengers.FirstOrDefault(x => x.PhoneNumber == passenger.PhoneNumber) != null)
            {
                throw new ArgumentException("Client with this phone number already registered", nameof(passenger));
            }

            _whooberContext.Passengers.Add(passenger);
            _whooberContext.SaveChanges();
        }

        public IReadOnlyCollection<Trip> GetTripHistory(Passenger passenger)
        {
            return _whooberContext.Trips.Where(x => x.Order.Passenger == passenger).ToList();
        }

        public Passenger FindPassengerById(Guid id)
        {
            return _whooberContext.Passengers.FirstOrDefault(x => x.Id == id);
        }
    }
}