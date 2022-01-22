using System;
using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class TripService : ITripService
    {
        private List<Trip> _activeTrips;
        private IServiceMediator _serviceMediator;
        public TripService()
        {
            _activeTrips = new List<Trip>();
        }

        public Trip CreateTrip(Order order, Driver driver)
        {
            var trip = new Trip(order, driver, driver.Car);
            _activeTrips.Add(trip);
            return trip;
        }

        public void ChangeTripState(Trip trip, TripState state)
        {
            if (!_activeTrips.Contains(trip))
            {
                throw new ArgumentException("Trip is not found", nameof(trip));
            }

            trip.State = state;
            if (state == TripState.FinishedUnpaid)
            {
                _activeTrips.Remove(trip);
            }
        }

        public TripState GetTripState(Trip trip)
        {
            return !_activeTrips.Contains(trip) ? TripState.FinishedUnpaid : trip.State;
        }

        public Trip GetActiveTripByDriver(Driver driver)
        {
            return _activeTrips.FirstOrDefault(x => x.Driver == driver);
        }

        public void SetServiceMediator(IServiceMediator mediator)
        {
            _serviceMediator = mediator;
        }
    }
}