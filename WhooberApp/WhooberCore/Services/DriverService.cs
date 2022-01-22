using System;
using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class DriverService : IDriverService
    {
        private List<Driver> _drivers;
        private IServiceMediator _serviceMediator;
        public DriverService()
        {
            _drivers = new List<Driver>();
        }

        public void RegisterDriver(Driver driver)
        {
            if (_drivers.Contains(driver))
            {
                throw new ArgumentException("Driver already registered", nameof(driver));
            }

            _drivers.Add(driver);
        }

        public void SetDriverStateToWorking(Driver driver)
        {
            driver.State = DriverState.Driving;
        }

        public void SetDriverStateToInactive(Driver driver)
        {
            driver.State = DriverState.Inactive;
        }

        public void SetDriverStateToWaiting(Driver driver)
        {
            driver.State = DriverState.Waiting;
        }

        public void AcceptOrder(Driver driver, Order order)
        {
            driver.State = DriverState.Driving;
            var trip = new Trip(order, driver, driver.Car);
        }

        public bool ChangeTripState(TripState state)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Driver> GetActiveDrivers()
        {
            return _drivers.Where(x => x.State == DriverState.Waiting).ToList();
        }

        public void SetServiceMediator(IServiceMediator mediator)
        {
            _serviceMediator = mediator;
        }
    }
}