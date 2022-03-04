using NUnit.Framework;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.InfrastructureAbstractions;

namespace WhooberServiceTests
{
    public class ClientServiceTests
    {
        private IClientService _clientService;
        [SetUp]
        public void SetUp()
        {
            var initialization = new TestsInitialization();
            _clientService = initialization.ClientService;
        }

        [Test]
        public void TestRegisterAndFindClient()
        {
            var dto = new AccountInfoDto()
            {
                PhoneNumber = "89996661488",
                Password = "123",
            };
            var passenger = new Passenger("pAssnger", dto.PhoneNumber);
            _clientService.RegisterPassenger(passenger);
            Assert.AreNotEqual(_clientService.FindPassengerById(passenger.Id), null);
        }

        [Test]
        public void TestGetTripHistory()
        {
            var dto = new AccountInfoDto()
            {
                PhoneNumber = "89996661487",
                Password = "123",
            };
            var passenger = new Passenger("pAssnger", dto.PhoneNumber);
            _clientService.RegisterPassenger(passenger);
            Assert.AreEqual(_clientService.GetTripHistory(passenger.Id).Count, 0);
        }
    }
}