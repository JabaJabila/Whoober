using System.Collections.Generic;
using System.Linq;
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

        public void RegisterDriver(Driver driver, AccountInfoDto accountInfoDto)
        {
            if (_whooberContext.Drivers.FirstOrDefault(x => x.PhoneNumber == driver.PhoneNumber) != null)
                throw new PersonException($"Driver with {driver.PhoneNumber} phone number already registered");

            _whooberContext.Drivers.Add(driver);
            accountInfoDto.ClientIdInDb = driver.Id;
            _whooberContext.Accounts.Add(accountInfoDto);
            _whooberContext.SaveChanges();
        }

        public void SetDriverStateToWorking(Driver driver)
        {
            driver.State = DriverState.Driving;
            _whooberContext.SaveChanges();
        }

        public void SetDriverStateToInactive(Driver driver)
        {
            driver.State = DriverState.Inactive;
            _whooberContext.SaveChanges();
        }

        public void SetDriverStateToWaiting(Driver driver)
        {
            driver.State = DriverState.Waiting;
            _whooberContext.SaveChanges();
        }

        public void AcceptOrder(Driver driver, Order order)
        {
            driver.State = DriverState.Driving;
        }

        public void ChangeTripStateToAwaitDriver(Driver driver)
        {
            Trip trip = _serviceMediator.FindActiveTripByDriver(driver);
            _serviceMediator.ChangeTripStateToAwaitDriver(trip);
        }

        public void ChangeTripStateToAwaitClient(Driver driver)
        {
            Trip trip = _serviceMediator.FindActiveTripByDriver(driver);
            _serviceMediator.ChangeTripStateToAwaitClient(trip);
        }

        public void ChangeTripStateToOnTheWay(Driver driver)
        {
            Trip trip = _serviceMediator.FindActiveTripByDriver(driver);
            _serviceMediator.ChangeTripStateToOnTheWay(trip);
        }

        public void ChangeTripStateToFinished(Driver driver)
        {
            Trip trip = _serviceMediator.FindActiveTripByDriver(driver);
            _serviceMediator.ChangeTripStateToFinished(trip);
            SetDriverStateToWaiting(driver);
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