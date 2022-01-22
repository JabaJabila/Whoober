using System;
using WhooberCore.Domain.Entities.PaymentAbstraction;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.Entities
{
    public class Driver
    {
        public Driver(string name, string phoneNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
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
        public IPaymentMethod PaymentMethod { get; set; }
        public string PhoneNumber { get; private set; }
    }
}