using System;
using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.Exceptions;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;

namespace WhooberInfrastructure.Services
{
    public class TripService : ITripService
    {
        private readonly WhooberContext _whooberContext;
        private IServiceMediator _serviceMediator;

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
            trip.State = TripState.FinishedUnpaid;
            if (_serviceMediator.ConfirmPayment(trip.Order.Passenger.PaymentMethod, trip))
            {
                trip.State = TripState.FinishedPaid;
            }

            _whooberContext.SaveChanges();
        }

        public TripState GetTripStateById(Guid id)
        {
            Trip trip = _whooberContext.Trips.FirstOrDefault(x => x.Id == id)
                        ?? throw new TripException($"Trip {id} not found");
            return trip.State;
        }

        public Trip GetActiveTripByDriver(Driver driver)
        {
            return _whooberContext.Trips
                .FirstOrDefault(x => x.DriverId == driver.Id && x.State
                    != TripState.FinishedPaid && x.State != TripState.FinishedUnpaid);
        }

        public void SetServiceMediator(IServiceMediator mediator)
        {
            _serviceMediator = mediator;
        }
    }
}