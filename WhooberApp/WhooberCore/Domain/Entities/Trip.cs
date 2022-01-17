using System;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.Entities
{
    public class Trip
    {
        public Order Order { get; private init; }
        public Driver Driver { get; private init; }
        public Car Car { get; private init; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public TripState State { get; set; }

        public Trip(Order order, Driver driver, Car car)
        {
            Order = order ?? throw new ArgumentNullException(nameof(order));
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
            Car = car ?? throw new ArgumentNullException(nameof(car));
            State = TripState.AwaitDriver;
        }

        private Trip()
        {
        }
    }
}