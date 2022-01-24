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
    public class DriverService : IDriverService
    {
        private readonly WhooberContext _whooberContext;
        private IServiceMediator _serviceMediator;
        public DriverService(WhooberContext whooberContext)
        {
            _whooberContext = whooberContext;
        }

        public Driver RegisterDriver(Driver driver)
        {
            if (_whooberContext.Drivers.FirstOrDefault(x => x.PhoneNumber == driver.PhoneNumber) != null)
                throw new PersonException($"Driver with {driver.PhoneNumber} phone number already registered");

            _whooberContext.Drivers.Add(driver);
            _whooberContext.SaveChanges();
            return driver;
        }

        public bool UpdateLocation(Guid id, Location newLocation)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            driver.Location = newLocation;
            _whooberContext.SaveChanges();
            return true;
        }

        public Driver FindDriverById(Guid id)
        {
            return _whooberContext.Drivers.FirstOrDefault(x => x.Id == id);
        }

        public bool SetDriverStateToWorking(Guid id)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            driver.State = DriverState.Driving;
            _whooberContext.SaveChanges();
            return true;
        }

        public bool SetDriverStateToInactive(Guid id)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            driver.State = DriverState.Inactive;
            _whooberContext.SaveChanges();
            return true;
        }

        public bool SetDriverStateToWaiting(Guid id)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            driver.State = DriverState.Waiting;
            _whooberContext.SaveChanges();
            return true;
        }

        public bool AcceptOrder(Guid id, Order order)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            driver.State = DriverState.Driving;
            return true;
        }

        public bool DenyOrder(Guid id, Order order)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            return true;
        }

        public bool ChangeTripStateToAwaitDriver(Guid id)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            Trip trip = _serviceMediator.FindActiveTripByDriver(driver);
            _serviceMediator.ChangeTripStateToAwaitDriver(trip);
            return true;
        }

        public bool ChangeTripStateToAwaitClient(Guid id)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            Trip trip = _serviceMediator.FindActiveTripByDriver(driver);
            _serviceMediator.ChangeTripStateToAwaitClient(trip);
            return true;
        }

        public bool ChangeTripStateToOnTheWay(Guid id)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            Trip trip = _serviceMediator.FindActiveTripByDriver(driver);
            _serviceMediator.ChangeTripStateToOnTheWay(trip);
            return true;
        }

        public bool ChangeTripStateToFinished(Guid id)
        {
            Driver driver = FindDriverById(id) ?? throw new ArgumentException($"Driver with id {id} not found", nameof(id));
            Trip trip = _serviceMediator.FindActiveTripByDriver(driver);
            _serviceMediator.ChangeTripStateToFinished(trip);
            SetDriverStateToWaiting(id);
            return true;
        }

        public Driver UpdateDriver(Guid id)
        {
            Driver driver = FindDriverById(id);
            _whooberContext.SaveChanges();
            return driver;
        }

        public IReadOnlyCollection<Driver> GetActiveDrivers()
        {
            return _whooberContext.Drivers.Where(x => x.State == DriverState.Waiting).ToList();
        }

        public void SetServiceMediator(IServiceMediator mediator)
        {
            _serviceMediator = mediator;
        }
    }
}