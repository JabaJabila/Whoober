using System;
using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;

namespace WhooberInfrastructure.Services
{
    public class TripService : ITripService
    {
        private IServiceMediator _serviceMediator;
        private WhooberContext _whooberContext;
        public TripService(WhooberContext whooberContext)
        {
            _whooberContext = whooberContext;
        }

        public Trip CreateTrip(Order order, Driver driver)
        {
            var trip = new Trip(order, driver, driver.Car);
            _whooberContext.Trips.Add(trip);
            _whooberContext.SaveChanges();
            return trip;
        }

        public void ChangeTripStateToAwaitDriver(Trip trip)
        {
            trip.State = TripState.AwaitDriver;
            _whooberContext.SaveChanges();
        }

        public void ChangeTripStateToAwaitClient(Trip trip)
        {
            trip.State = TripState.AwaitClient;
            _whooberContext.SaveChanges();
        }

        public void ChangeTripStateToOnTheWay(Trip trip)
        {
            trip.State = TripState.OnTheWay;
            _whooberContext.SaveChanges();
        }

        public void ChangeTripStateToFinished(Trip trip)
        {
            // TODO
            trip.State = TripState.FinishedUnpaid;
            if (trip.Order.Passenger.PaymentMethod.Pay(trip.Order.Price))
            {
                trip.State = TripState.FinishedPaid;
            }

            _whooberContext.SaveChanges();
        }

        public TripState GetTripStateById(Guid id)
        {
            Trip trip = _whooberContext.Trips.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException();
            return trip.State;
        }

        public Trip GetActiveTripByDriver(Driver driver)
        {
            return _whooberContext.Trips.FirstOrDefault(x => x.Driver == driver && x.State != TripState.FinishedPaid && x.State != TripState.FinishedUnpaid);
        }

        public void SetServiceMediator(IServiceMediator mediator)
        {
            _serviceMediator = mediator;
        }
    }
}