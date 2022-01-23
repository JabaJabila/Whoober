using System.Linq;
using NUnit.Framework;
using WhooberCore.Builders;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Dto;
using WhooberCore.InfrastructureAbstractions;
using WhooberCore.Payment;
using WhooberInfrastructure.Data;


namespace WhooberServiceTests
{
    public class TripServiceTests
    {
        private IOrderService _orderService;
        private IDriverService _driverService;
        private ITripService _tripService;
        private Driver _testDriver;
        private Trip _testTrip;
        private Location[] _routeCreated;
        private WhooberContext _context;
        [SetUp]
        public void SetUp()
        {
            var initialization = new TestsInitialization();
            _driverService = initialization.DriverService;
            var dto = new AccountInfoDto()
            {
                PhoneNumber = "88005553537",
                Password = "123",
            };
            _testDriver = new Driver("amogus", dto.PhoneNumber)
            {
                Car = new Car("kok", "red", "s228as", CarLevel.Economy),
            };
            _driverService.RegisterDriver(_testDriver, dto);
            _driverService.SetDriverStateToWaiting(_testDriver);
            _tripService = initialization.TripService;
            _orderService = initialization.OrderService;

            var passenger = new Passenger("abobus", "88005553535");
            passenger.PaymentMethod = new CardMethod(new DummyCard("2286661500"));
            var builder = new OrderRequestBuilder();
            builder.SetPassenger(passenger)
                .AddLocation(new Location(0, 0))
                .AddLocation(new Location(1, 1))
                .SetCarLevel(CarLevel.Economy);
            var request = builder.ToOrderRequest();
            _routeCreated = request.Route.Locations.ToArray();
            decimal price = _orderService.RequestTripCost(builder.ToOrderRequest());
            var order = new Order(request, price);
            _testTrip = _orderService.ApproveOrder(order);
            _driverService.AcceptOrder(_testDriver, order);
        }

        [Test]
        public void ChangeTripState()
        {
            _driverService.ChangeTripStateToAwaitClient(_testDriver);
            Assert.AreEqual(_tripService.GetTripStateById(_testTrip.Id), TripState.AwaitClient);
            Assert.AreEqual(_testDriver.State, DriverState.Driving);

            _driverService.ChangeTripStateToOnTheWay(_testDriver);
            Assert.AreEqual(_tripService.GetTripStateById(_testTrip.Id), TripState.OnTheWay);
            Assert.AreEqual(_testDriver.State, DriverState.Driving);

            _driverService.ChangeTripStateToFinished(_testDriver);
            Assert.AreEqual(_tripService.GetTripStateById(_testTrip.Id), TripState.FinishedUnpaid);
            Assert.AreEqual(_testDriver.State, DriverState.Waiting);
        }

        [Test]
        public void TestSaveAndLoadRoad()
        {
            var route = _tripService.GetActiveTripByDriver(_testDriver).Order.Route.Locations.ToArray();
            for (int i = 0; i < route.Length; i++)
            {
                Assert.AreEqual(route[i].Latitude, _routeCreated[i].Latitude);
                Assert.AreEqual(route[i].Longitude, _routeCreated[i].Longitude);
            }
        }
    }
}