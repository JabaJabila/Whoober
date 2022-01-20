using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class OrderService : IOrderService
    {
        private ICostDeterminator _costDeterminator;

        // List of orders to be approved or denied, removed from list after approval/denial
        private List<Order> _activeOrders;

        public OrderService(ICostDeterminator costDeterminator)
        {
            _activeOrders = new List<Order>();
            _costDeterminator = costDeterminator;
        }

        public decimal RequestTripCost(Order order)
        {
            return _costDeterminator.DefineTripCost(order);
        }

        public void ApproveOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void DenyOrder(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}