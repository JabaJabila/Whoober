using System;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.Entities
{
    public class Trip
    {
        public Trip(Order order, Driver driver, Car car)
        {
            Order = order ?? throw new ArgumentNullException(nameof(order));

            if (driver == null)
                throw new ArgumentNullException(nameof(driver));

            DriverId = driver.Id;

            if (car == null)
                throw new ArgumentNullException(nameof(car));

            CarId = car.Id;
            State = TripState.AwaitDriver;
        }

        private Trip()
        {
        }

        public Guid Id { get; private init; }
        public Order Order { get; private init; }
        public Guid DriverId { get; private init; }
        public Guid CarId { get; private init; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public TripState State { get; set; }
    }
}