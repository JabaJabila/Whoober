using NUnit.Framework;
using WhooberCore.Builders;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Dto;
using WhooberCore.InfrastructureAbstractions;

namespace WhooberServiceTests
{
    public class OrderServiceTests
    {
        private IOrderService _orderService;
        private IDriverService _driverService;
        private ITripService _tripService;
        private IClientService _clientService;
        [SetUp]
        public void SetUp()
        {
            var initialization = new TestsInitialization();
            var dto = new AccountInfoDto()
            {
                PhoneNumber = "88007770202",
                Password = "123",
            };
            var driver = new Driver("amogus", dto.PhoneNumber)
            {
                Car = new Car("kok", "red", "s228as", CarLevel.Economy),
            };
            _driverService = initialization.DriverService;
            _driverService.RegisterDriver(driver);
            _driverService.SetDriverStateToWaiting(driver.Id);
            _tripService = initialization.TripService;
            _orderService = initialization.OrderService;
            _clientService = initialization.ClientService;
        }

        [Test]
        public void TestCreateAndConfirmOrder()
        {
            var dto = new AccountInfoDto()
            {
                PhoneNumber = "88005553535",
                Password = "123",
            };
            var passenger = new Passenger("abobus", dto.PhoneNumber);
            _clientService.RegisterPassenger(passenger);
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