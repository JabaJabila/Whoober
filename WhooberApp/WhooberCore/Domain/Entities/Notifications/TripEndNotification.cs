using System;

namespace WhooberCore.Domain.Entities.Notifications
{
    public class TripEndNotification : INotification
    {
        public TripEndNotification(Trip trip)
        {
            Trip = trip ?? throw new ArgumentNullException(nameof(trip));
        }

        public Trip Trip { get; }
        public DateTime Time { get; }
    }
}