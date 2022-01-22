using System;

namespace WhooberCore.Domain.Entities.Notifications
{
    public class OrderRequestNotification : INotification
    {
        public OrderRequestNotification(Order order)
        {
            Order = order ?? throw new ArgumentNullException(nameof(order));
        }

        public Order Order { get; }
        public DateTime Time { get; }
    }
}