using System;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.PaymentAbstraction;
using WhooberCore.Payment;

namespace WhooberCore.Domain.Entities
{
    public class Driver
    {
        public Driver(string name, string phoneNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Rating = new Rating();
            PaymentMethod = new CashPayment();
            State = DriverState.Inactive;
        }

        private Driver()
        {
        }

        public Guid Id { get; init; }
        public string Name { get; private init; }
        public Rating Rating { get; private init; }
        public Car Car { get; set; }
        public Location Location { get; set; }
        public DriverState State { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public BaseCard SavedCard { get; set; }
        public string PhoneNumber { get; private set; }
    }
}