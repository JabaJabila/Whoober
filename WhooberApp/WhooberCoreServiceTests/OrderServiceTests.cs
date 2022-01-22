using NUnit.Framework;
using WhooberCore.Algorithms;
using WhooberCore.Builders;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.ServiceAbstractions;
using WhooberCore.Services;

namespace WhooberCoreServiceTests
{
    public class OrderServiceTests
    {
        private IOrderService _orderService;
        private IDriverService _driverService;
        private ITripService _tripService;
        [SetUp]
        public void SetUp()
        {
            ICostDeterminer costDeterminer = new FixedFairCostDeterminer(10, new EuclidDistanceCount());
            IDriverFinder driverFinder = new DriverFinder(new EuclidDistanceCount());
            _driverService = new DriverService();
            var driver = new Driver("amogus", "88005553535")
            {
                Car = new Car("kok", "red", "s228as", CarLevel.Economy),
            };
            _driverService.RegisterDriver(driver);
            _driverService.SetDriverStateToWaiting(driver);
            _tripService = new TripService();
            _orderService = new OrderService(costDeterminer, driverFinder);
            IServiceMediator serviceMediator = new ServiceMediator(_driverService, _tripService, _orderService);
        }

        [Test]
        public void TestCreateAndConfirmOrder()
        {
            var passenger = new Passenger("abobus", "88005553535");
            var builder = new OrderRequestBuilder();
            builder.SetPassenger(passenger)
                .AddLocation(new Location(0, 0))
                .AddLocation(new Location(1, 1))
                .SetCarLevel(CarLevel.Economy);
            var request = builder.ToOrderRequest();
            decimal price = _orderService.RequestTripCost(builder.ToOrderRequest());
            var order = new Order(request, price);
            Trip trip = _orderService.ApproveOrder(order);
            Assert.That(_tripService.GetTripState(trip) == TripState.OnTheWay);
        }
    }
}