using NUnit.Framework;
using WhooberCore.Domain.Entities;
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
            var passenger = new Passenger("pAssnger", "89996661488");
            _clientService.RegisterPassenger(passenger);
            Assert.AreNotEqual(_clientService.FindPassengerById(passenger.Id), null);
        }

        [Test]
        public void TestGetTripHistory()
        {
            var passenger = new Passenger("pAssnger", "89996661487");
            _clientService.RegisterPassenger(passenger);
            Assert.AreEqual(_clientService.GetTripHistory(_clientService.FindPassengerById(passenger.Id)).Count, 0);
        }
    }
}