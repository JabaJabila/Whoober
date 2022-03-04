using System;

namespace WhooberCore.Domain.Entities.Notifications
{
    public class DriverFoundNotification : INotification
    {
        public DriverFoundNotification(Trip trip)
        {
            Trip = trip ?? throw new ArgumentNullException(nameof(trip));
        }

        public Trip Trip { get; }
        public DateTime Time { get; }
    }
}