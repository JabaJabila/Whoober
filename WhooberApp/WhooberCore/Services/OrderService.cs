using System;
using System.Collections.Generic;
using WhooberCore.Domain.AlgoritmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICostDeterminer _costDeterminer;

        // List of orders to be approved or denied, removed from list after approval/denial
        private List<Order> _activeOrders;

        public OrderService(ICostDeterminer costDeterminer)
        {
            _activeOrders = new List<Order>();
            _costDeterminer = costDeterminer;
        }

        public decimal RequestTripCost(OrderRequest orderRequest)
        {
            return _costDeterminer.DefineTripCost(orderRequest);
        }

        public void ApproveOrder(Order order)
        {
            if (!_activeOrders.Remove(order))
            {
                throw new ArgumentException("Order not found", nameof(order));
            }

            // TODO approve order logic
        }

        public void DenyOrder(Order order)
        {
            if (!_activeOrders.Remove(order))
            {
                throw new ArgumentException("Order not found", nameof(order));
            }

            // TODO deny order logic
        }
    }
}