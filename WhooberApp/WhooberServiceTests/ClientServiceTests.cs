using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WhooberCore.Domain.Entities;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;
using WhooberInfrastructure.Services;

namespace WhooberServiceTests
{
    public class ClientServiceTests
    {
        private IClientService _clientService;
        [SetUp]
        public void SetUp()
        {
            DbContextOptions<WhooberContext> options = new DbContextOptionsBuilder<WhooberContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            var context = new WhooberContext(options);
            _clientService = new ClientService(context);
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
            var passenger = new Passenger("pAssnger", "89996661488");
            _clientService.RegisterPassenger(passenger);
            Assert.AreEqual(_clientService.FindPassengerById(passenger.Id), 0);
        }
    }
}