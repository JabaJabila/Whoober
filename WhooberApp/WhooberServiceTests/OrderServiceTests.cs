using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WhooberCore.Algorithms;
using WhooberCore.Builders;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;
using WhooberInfrastructure.Services;

namespace WhooberServiceTests
{
    public class OrderServiceTests
    {
        private IOrderService _orderService;
        private IDriverService _driverService;
        private ITripService _tripService;
        [SetUp]
        public void SetUp()
        {
            ICostDeterminer costDeterminer = new FixedFairCostDeterminer(new EuclidDistanceCount());
            IDriverFinder driverFinder = new DriverFinder(new EuclidDistanceCount());
            var options = new DbContextOptionsBuilder<WhooberContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            var context = new WhooberContext(options);
            _driverService = new DriverService(new WhooberContext(options));
            var driver = new Driver("amogus", "88005553535")
            {
                Car = new Car("kok", "red", "s228as", CarLevel.Economy),
            };
            _driverService.RegisterDriver(driver);
            _driverService.SetDriverStateToWaiting(driver);
            _tripService = new TripService(context);
            _orderService = new OrderService(costDeterminer, driverFinder, context);
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
            Assert.That(_tripService.GetTripStateById(trip.Id) == TripState.AwaitDriver);
        }
    }
}