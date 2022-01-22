using NUnit.Framework;
using WhooberCore.Algorithms;
using WhooberCore.Domain.AlgoritmsAbstractions;
using WhooberCore.Domain.Builders;
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
            _orderService = new OrderService(costDeterminer);
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
            decimal price = _orderService.RequestTripCost(builder.ToOrderRequest());

            // Assert.That(_orderService.DenyOrder());
        }
    }
}