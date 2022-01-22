using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.PaymentAbstraction;
using WhooberCore.InfrastructureAbstractions;

namespace WhooberInfrastructure.Services
{
    public class ServiceMediator : IServiceMediator
    {
        private readonly IDriverService _driverService;
        private readonly ITripService _tripService;
        private readonly IOrderService _orderService;
        private readonly IPaymentConfirmationService _paymentConfirmationService;
        public ServiceMediator(IDriverService driverService, ITripService tripService, IOrderService orderService, IPaymentConfirmationService paymentConfirmationService)
        {
            _driverService = driverService;
            _driverService.SetServiceMediator(this);
            _tripService = tripService;
            _tripService.SetServiceMediator(this);
            _orderService = orderService;
            _orderService.SetServiceMediator(this);
            _paymentConfirmationService = paymentConfirmationService;
            _paymentConfirmationService.SetServiceMediator(this);
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

        public bool ConfirmPayment(PaymentMethod method, Trip trip)
        {
            return _paymentConfirmationService.ConfirmPayment(method, trip.Order.Price);
        }
    }
}