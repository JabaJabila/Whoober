using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
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

        public IReadOnlyCollection<Driver> GetActiveDriversByCarLevel(CarLevel carLevel)
        {
            return _driverService.GetActiveDrivers().Where(x => x.Car.Level == carLevel).ToList();
        }

        public Trip ConfirmOrder(Order order, Driver driver)
        {
            return _tripService.CreateTrip(order, driver);
        }
    }
}