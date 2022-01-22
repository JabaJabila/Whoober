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
        [SetUp]
        public void SetUp()
        {
            ICostDeterminer costDeterminer = new FixedFairCostDeterminer(10, new EuclidRouteLengthCount());
            IDriverFinder driverFinder = new DriverFinder();
            IServiceMediator serviceMediator = new ServiceMediator();
            _orderService = new OrderService(costDeterminer, driverFinder, serviceMediator);
        }

        [Test]
        public void TestCreateOrder()
        {
            var passenger = new Passenger("abobus");
            var builder = new OrderRequestBuilder();
            builder.SetPassenger(passenger)
                .AddLocation(new Location(0, 0))
                .AddLocation(new Location(1, 1))
                .SetCarLevel(CarLevel.Business);
            var request = builder.ToOrderRequest();
            decimal price = _orderService.RequestTripCost(builder.ToOrderRequest());
            var order = new Order(request, price);
            // Assert.Pass(_orderService.ApproveOrder(order));
        }
    }
}