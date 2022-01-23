using NUnit.Framework;
using WhooberCore.Builders;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Dto;
using WhooberCore.InfrastructureAbstractions;
using WhooberCore.Payment;

namespace WhooberServiceTests
{
    public class PaymentServiceTests
    {
        private Trip _trip1;
        private Trip _trip2;
        private Passenger _passenger1;
        private Passenger _passenger2;
        private decimal _price1;
        private decimal _price2;
        private ITripService _tripService;

        [SetUp]
        public void SetUp()
        {
            var initialization = new TestsInitialization();
            _tripService = initialization.TripService;
            var dto1 = new AccountInfoDto()
            {
                PhoneNumber = "88005553535",
                Password = "123",
            };
            var driver1 = new Driver("amogus1", dto1.PhoneNumber)
            {
                Car = new Car("kok", "red", "s228as", CarLevel.Economy),
            };
            var dto2 = new AccountInfoDto()
            {
                PhoneNumber = "88005553536",
                Password = "123",
            };
            var driver2 = new Driver("amogus2", dto2.PhoneNumber)
            {
                Car = new Car("kok", "blue", "s229as", CarLevel.Elite),
            };
            driver1.State = DriverState.Waiting;
            driver2.State = DriverState.Waiting;
            initialization.DriverService.RegisterDriver(driver1);
            initialization.DriverService.RegisterDriver(driver2);
            dto1 = new AccountInfoDto()
            {
                PhoneNumber = "89996661489",
                Password = "123",
            };
            _passenger1 = new Passenger("pAssnger1", dto1.PhoneNumber)
            {
                PaymentMethod = new CardMethod(new DummyCard("111111111111111")),
            };
            dto2 = new AccountInfoDto()
            {
                PhoneNumber = "89996661477",
                Password = "123",
            };
            _passenger2 = new Passenger("pAssnger2", dto2.PhoneNumber)
            {
                PaymentMethod = new CardMethod(new DummyCard("111111111111112")),
            };
            initialization.ClientService.RegisterPassenger(_passenger1, dto1);
            initialization.ClientService.RegisterPassenger(_passenger2, dto2);

            // Create orders
            var builder = new OrderRequestBuilder();
            builder.SetPassenger(_passenger1)
                .AddLocation(new Location(0, 0))
                .AddLocation(new Location(1, 1))
                .SetCarLevel(CarLevel.Economy);

            // client 1 has enough money
            var request1 = builder.ToOrderRequest();
            _price1 = initialization.OrderService.RequestTripCost(request1);

            builder.SetPassenger(_passenger2)
                .AddLocation(new Location(0, 0))
                .AddLocation(new Location(3, 3))
                .SetCarLevel(CarLevel.Elite);

            var request2 = builder.ToOrderRequest();
            _price2 = initialization.OrderService.RequestTripCost(request2);
            _passenger1.PaymentMethod.Receive(_price1);

            // client 2 has not enough money
            _passenger2.PaymentMethod.Receive(_price2 - 1);

            var order1 = new Order(request1, _price1);
            var order2 = new Order(request2, _price2);
            _trip1 = initialization.OrderService.ApproveOrder(order1);
            _trip2 = initialization.OrderService.ApproveOrder(order2);
            initialization.DriverService.AcceptOrder(driver1.Id, order1);
            initialization.DriverService.AcceptOrder(driver2.Id, order2);
        }

        [Test]
        public void TestPayment()
        {
            _tripService.ChangeTripStateToFinished(_trip1);
            Assert.AreEqual(_tripService.GetTripStateById(_trip1.Id), TripState.FinishedPaid);

            _tripService.ChangeTripStateToFinished(_trip2);
            Assert.AreEqual(_tripService.GetTripStateById(_trip2.Id), TripState.FinishedUnpaid);
        }
    }
}