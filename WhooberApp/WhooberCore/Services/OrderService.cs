using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICostDeterminer _costDeterminer;
        private readonly IDriverFinder _driverFinder;
        private readonly IServiceMediator _serviceMediator;
        public OrderService(ICostDeterminer costDeterminer, IDriverFinder driverFinder, IServiceMediator serviceMediator)
        {
            _costDeterminer = costDeterminer;
            _driverFinder = driverFinder;
            _serviceMediator = serviceMediator;
        }

        public decimal RequestTripCost(OrderRequest orderRequest)
        {
            return _costDeterminer.DefineTripCost(orderRequest);
        }

        public Trip ApproveOrder(Order order)
        {
            // TODO approve order logic
            Driver driver = _driverFinder.FindDriver(order, _serviceMediator.GetActiveDrivers());
            return _serviceMediator.ConfirmOrder(order, driver);
        }
    }
}