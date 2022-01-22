using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WhooberCore.Algorithms;
using WhooberCore.Builders;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.InfrastructureAbstractions;
using WhooberCore.Payment;
using WhooberInfrastructure.Data;
using WhooberInfrastructure.Services;

namespace WhooberServiceTests
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
            var options = new DbContextOptionsBuilder<WhooberContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            var context = new TestingDbContext(options);
            ICostDeterminer costDeterminer = new FixedFairCostDeterminer(10, new EuclidDistanceCount());
            IDriverFinder driverFinder = new DriverFinder(new EuclidDistanceCount());
            _driverService = new DriverService(context);
            _testDriver = new Driver("amogus", "88005553535")
            {
                Car = new Car("kok", "red", "s228as", CarLevel.Economy),
            };
            _driverService.RegisterDriver(_testDriver);
            _driverService.SetDriverStateToWaiting(_testDriver);
            _tripService = new TripService(context);
            _orderService = new OrderService(costDeterminer, driverFinder, context);
            IServiceMediator serviceMediator = new ServiceMediator(_driverService, _tripService, _orderService);

            var passenger = new Passenger("abobus", "88005553535");
            passenger.PaymentMethod = new CardMethod(new DummyCard("2286661488"));
            var builder = new OrderRequestBuilder();
            builder.SetPassenger(passenger)
                .AddLocation(new Location(0, 0))
                .AddLocation(new Location(1, 1))
                .SetCarLevel(CarLevel.Economy);
            var request = builder.ToOrderRequest();
            decimal price = _orderService.RequestTripCost(builder.ToOrderRequest());
            var order = new Order(request, price);
            _testTrip = _orderService.ApproveOrder(order);
            _driverService.AcceptOrder(_testDriver, order);
        }

        [Test]
        public void ChangeTripState()
        {
            _driverService.ChangeTripStateToAwaitClient(_testDriver);
            Assert.AreEqual(_tripService.GetTripState(_testTrip), TripState.AwaitClient);
            Assert.AreEqual(_testDriver.State, DriverState.Driving);

            _driverService.ChangeTripStateToOnTheWay(_testDriver);
            Assert.AreEqual(_tripService.GetTripState(_testTrip), TripState.OnTheWay);
            Assert.AreEqual(_testDriver.State, DriverState.Driving);

            _driverService.ChangeTripStateToFinished(_testDriver);
            Assert.AreEqual(_tripService.GetTripState(_testTrip), TripState.FinishedPaid);
            Assert.AreEqual(_testDriver.State, DriverState.Waiting);
        }
    }
}