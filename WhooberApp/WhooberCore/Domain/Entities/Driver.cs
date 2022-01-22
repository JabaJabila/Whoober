using System;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.Entities
{
    public class Driver
    {
        public Driver(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Rating = new Rating();
            State = DriverState.Inactive;
        }

        private Driver()
        {
        }

        public Guid Id { get; private init; }
        public string Name { get; private init; }
        public Rating Rating { get; private init; }
        public Car Car { get; set; }
        public Location Location { get; set; }
        public DriverState State { get; set; }
    }
}