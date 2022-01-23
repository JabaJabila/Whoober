using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.Exceptions;
using WhooberCore.Dto;
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

        public void RegisterDriver(Driver driver)
        {
            if (_whooberContext.Drivers.FirstOrDefault(x => x.PhoneNumber == driver.PhoneNumber) != null)
                throw new PersonException($"Driver with {driver.PhoneNumber} phone number already registered");

            _whooberContext.Drivers.Add(driver);
            _whooberContext.SaveChanges();
        }

        public Driver FindDriverById(Guid id)
        {
            return _whooberContext.Drivers.FirstOrDefault(x => x.Id == id);
        }

        public void SetDriverStateToWorking(Guid id)
        {
            FindDriverById(id).State = DriverState.Driving;
            _whooberContext.SaveChanges();
        }

        public void SetDriverStateToInactive(Guid id)
        {
            FindDriverById(id).State = DriverState.Inactive;
            _whooberContext.SaveChanges();
        }

        public void SetDriverStateToWaiting(Guid id)
        {
            FindDriverById(id).State = DriverState.Waiting;
            _whooberContext.SaveChanges();
        }

        public void AcceptOrder(Guid id, Order order)
        {
            FindDriverById(id).State = DriverState.Driving;
        }

        public void ChangeTripStateToAwaitDriver(Guid id)
        {
            Trip trip = _serviceMediator.FindActiveTripByDriver(FindDriverById(id));
            _serviceMediator.ChangeTripStateToAwaitDriver(trip);
        }

        public void ChangeTripStateToAwaitClient(Guid id)
        {
            Trip trip = _serviceMediator.FindActiveTripByDriver(FindDriverById(id));
            _serviceMediator.ChangeTripStateToAwaitClient(trip);
        }

        public void ChangeTripStateToOnTheWay(Guid id)
        {
            Trip trip = _serviceMediator.FindActiveTripByDriver(FindDriverById(id));
            _serviceMediator.ChangeTripStateToOnTheWay(trip);
        }

        public void ChangeTripStateToFinished(Guid id)
        {
            Trip trip = _serviceMediator.FindActiveTripByDriver(FindDriverById(id));
            _serviceMediator.ChangeTripStateToFinished(trip);
            SetDriverStateToWaiting(id);
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