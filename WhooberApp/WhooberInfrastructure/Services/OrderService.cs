using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.InfrastructureAbstractions;
using WhooberInfrastructure.Data;

namespace WhooberInfrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICostDeterminer _costDeterminer;
        private readonly IDriverFinder _driverFinder;
        private IServiceMediator _serviceMediator;
        private WhooberContext _whooberContext;
        public OrderService(ICostDeterminer costDeterminer, IDriverFinder driverFinder, WhooberContext whooberContext)
        {
            _costDeterminer = costDeterminer;
            _driverFinder = driverFinder;
            _whooberContext = whooberContext;
        }

        public decimal RequestTripCost(OrderRequest orderRequest)
        {
            return _costDeterminer.DefineTripCost(orderRequest);
        }

        public Trip ApproveOrder(Order order)
        {
            // TODO approve order logic
            Driver driver = _driverFinder.FindDriver(order, _serviceMediator.GetActiveDriversByCarLevel(order.CarLevel));
            return _serviceMediator.ConfirmOrder(order, driver);
        }

        public void SetServiceMediator(IServiceMediator mediator)
        {
            _serviceMediator = mediator;
        }
    }
}