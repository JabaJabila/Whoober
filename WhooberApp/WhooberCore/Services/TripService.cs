using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class TripService : ITripService
    {
        public Trip CreateTrip(Order order, Driver driver)
        {
            var trip = new Trip(order, driver, driver.Car);
            return trip;
        }

        public void ChangeTripState(Trip trip, TripState state)
        {
            trip.State = state;
        }
    }
}