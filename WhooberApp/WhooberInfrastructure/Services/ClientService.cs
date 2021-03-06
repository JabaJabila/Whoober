using System;
using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Exceptions;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;

namespace WhooberInfrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly WhooberContext _whooberContext;
        public ClientService(WhooberContext whooberContext)
        {
            _whooberContext = whooberContext;
        }

        public Passenger RegisterPassenger(Passenger passenger)
        {
            if (_whooberContext.Passengers.FirstOrDefault(x => x.PhoneNumber == passenger.PhoneNumber) != null)
                throw new PersonException($"Passenger with {passenger.PhoneNumber} phone number already registered");

            _whooberContext.Passengers.Add(passenger);
            _whooberContext.SaveChanges();
            return passenger;
        }

        public IReadOnlyCollection<Trip> GetTripHistory(Guid id)
        {
            return _whooberContext.Trips.Where(x => x.Order.Passenger == FindPassengerById(id)).ToList();
        }

        public Passenger FindPassengerById(Guid id)
        {
            return _whooberContext.Passengers.FirstOrDefault(x => x.Id == id);
        }

        public Trip GetActiveTrip(Guid passengerId)
        {
            return _whooberContext.Trips.FirstOrDefault(trip => trip.Order.Passenger.Id == passengerId);
        }
    }
}