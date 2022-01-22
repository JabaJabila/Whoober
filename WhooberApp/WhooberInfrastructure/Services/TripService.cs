using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.InfrastructureAbstractions;

namespace WhooberInfrastructure.Services
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

        public void ChangeTripStateToAwaitDriver(Trip trip)
        {
            trip.State = TripState.AwaitDriver;
        }

        public void ChangeTripStateToAwaitClient(Trip trip)
        {
            trip.State = TripState.AwaitClient;
        }

        public void ChangeTripStateToOnTheWay(Trip trip)
        {
            trip.State = TripState.OnTheWay;
        }

        public void ChangeTripStateToFinished(Trip trip)
        {
            // TODO
            trip.State = TripState.FinishedUnpaid;
            if (trip.Order.Passenger.PaymentMethod.Pay(trip.Order.Price))
            {
                trip.State = TripState.FinishedPaid;
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