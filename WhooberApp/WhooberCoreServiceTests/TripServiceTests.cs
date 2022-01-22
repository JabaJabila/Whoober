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
    public class TripServiceTests
    {
        private IOrderService _orderService;
        private IDriverService _driverService;
        private ITripService _tripService;
        private Driver _testDriver;
        private Trip _testTrip;
        [SetUp]
        public void SetUp()
        {
            ICostDeterminer costDeterminer = new FixedFairCostDeterminer(10, new EuclidDistanceCount());
            IDriverFinder driverFinder = new DriverFinder(new EuclidDistanceCount());
            _driverService = new DriverService();
            _testDriver = new Driver("amogus", "88005553535")
            {
                Car = new Car("kok", "red", "s228as", CarLevel.Economy),
            };
            _driverService.RegisterDriver(_testDriver);
            _driverService.SetDriverStateToWaiting(_testDriver);
            _tripService = new TripService();
            _orderService = new OrderService(costDeterminer, driverFinder);
            IServiceMediator serviceMediator = new ServiceMediator(_driverService, _tripService, _orderService);

            var passenger = new Passenger("abobus", "88005553535");
            var builder = new OrderRequestBuilder();
            builder.SetPassenger(passenger)
                .AddLocation(new Location(0, 0))
                .AddLocation(new Location(1, 1))
                .SetCarLevel(CarLevel.Economy);
            var request = builder.ToOrderRequest();
            decimal price = _orderService.RequestTripCost(builder.ToOrderRequest());
            var order = new Order(request, price);
            _testTrip = _orderService.ApproveOrder(order);
        }

        [Test]
        public void ChangeTripState()
        {
            _driverService.ChangeTripState(_testDriver, TripState.AwaitClient);
            Assert.That(_tripService.GetTripState(_testTrip) == TripState.AwaitClient);

            _driverService.ChangeTripState(_testDriver, TripState.OnTheWay);
            Assert.That(_tripService.GetTripState(_testTrip) == TripState.OnTheWay);

            _driverService.ChangeTripState(_testDriver, TripState.FinishedUnpaid);
            Assert.That(_tripService.GetTripState(_testTrip) == TripState.FinishedUnpaid);
        }
    }
}