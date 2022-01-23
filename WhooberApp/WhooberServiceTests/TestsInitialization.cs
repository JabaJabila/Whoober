using Microsoft.EntityFrameworkCore;
using WhooberCore.Algorithms;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;
using WhooberInfrastructure.Services;

namespace WhooberServiceTests
{
    public class TestsInitialization
    {
        public TestsInitialization()
        {
            SetUp();
        }

        public IClientService ClientService { get; private set; }
        public IOrderService OrderService { get; private set; }
        public IDriverService DriverService { get; private set; }
        public ITripService TripService { get; private set; }
        public IPaymentConfirmationService PaymentConfirmationService { get; private set; }
        public IServiceMediator ServiceMediator { get; private set; }

        public void SetUp()
        {
            DbContextOptions<WhooberContext> options = new DbContextOptionsBuilder<WhooberContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            var context = new WhooberContext(options);

            context.Database.EnsureDeleted();
            ICostDeterminer costDeterminer = new FixedFairCostDeterminer(new EuclidDistanceCount());
            IDriverFinder driverFinder = new DriverFinder(new EuclidDistanceCount());

            TripService = new TripService(context);
            OrderService = new OrderService(costDeterminer, driverFinder, context);
            ClientService = new ClientService(context);
            DriverService = new DriverService(context);
            PaymentConfirmationService = new PaymentService(context);
            ServiceMediator = new ServiceMediator(DriverService, TripService, OrderService, PaymentConfirmationService);
        }
    }
}