using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.InfrastructureAbstractions;

namespace WhooberInfrastructure.Services
{
    public class ServiceMediator : IServiceMediator
    {
        private readonly IDriverService _driverService;
        private readonly ITripService _tripService;
        private readonly IOrderService _orderService;
        public ServiceMediator(IDriverService driverService, ITripService tripService, IOrderService orderService)
        {
            _driverService = driverService;
            _driverService.SetServiceMediator(this);
            _tripService = tripService;
            _orderService = orderService;
            _orderService.SetServiceMediator(this);
        }

        public IReadOnlyCollection<Driver> GetActiveDriversByCarLevel(CarLevel carLevel)
        {
            return _driverService.GetActiveDrivers().Where(x => x.Car.Level == carLevel).ToList();
        }

        public Trip ConfirmOrder(Order order, Driver driver)
        {
            return _tripService.CreateTrip(order, driver);
        }

        public void ChangeTripStateToAwaitDriver(Trip trip)
        {
            _tripService.ChangeTripStateToAwaitDriver(trip);
        }

        public void ChangeTripStateToAwaitClient(Trip trip)
        {
            _tripService.ChangeTripStateToAwaitClient(trip);
        }

        public void ChangeTripStateToOnTheWay(Trip trip)
        {
            _tripService.ChangeTripStateToOnTheWay(trip);
        }

        public void ChangeTripStateToFinished(Trip trip)
        {
            _tripService.ChangeTripStateToFinished(trip);
        }

        public Trip FindActiveTripByDriver(Driver driver)
        {
            return _tripService.GetActiveTripByDriver(driver);
        }
    }
}