using System.Collections.Generic;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class ServiceMediator : IServiceMediator
    {
        private readonly IDriverService _driverService;
        private readonly ITripService _tripService;
        public ServiceMediator(IDriverService driverService, ITripService tripService)
        {
            _driverService = driverService;
            _tripService = tripService;
        }

        public IReadOnlyCollection<Driver> GetActiveDrivers()
        {
            return _driverService.GetActiveDrivers();
        }

        public Trip ConfirmOrder(Order order, Driver driver)
        {
            return _tripService.CreateTrip(order, driver);
        }
    }
}