using System;
using System.Collections.Generic;
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
            trip.State = TripState.OnTheWay;
            return trip;
        }

        public void ChangeTripState(Trip trip, TripState state)
        {
            if (!_activeTrips.Contains(trip))
            {
                throw new ArgumentException("Trip is not found", nameof(trip));
            }

            trip.State = state;
            if (state == TripState.Finished)
            {
                _activeTrips.Remove(trip);
            }
        }

        public TripState GetTripState(Trip trip)
        {
            return !_activeTrips.Contains(trip) ? TripState.Finished : trip.State;
        }

        public void SetServiceMediator(IServiceMediator mediator)
        {
            _serviceMediator = mediator;
        }
    }
}