using System;
using WhooberCore.Domain.PaymentAbstraction;
using WhooberCore.Payment;

namespace WhooberCore.Domain.Entities
{
    public class Passenger
    {
        public Passenger(string name, string phoneNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            PaymentMethod = new CashPayment();
            Rating = new Rating();
        }

        private Passenger()
        {
        }

        public Guid Id { get; init; }
        public string Name { get; set; }
        public Rating Rating { get; private init; }
        public Location Location { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public BaseCard SavedCard { get; set; }
        public string PhoneNumber { get; private set; }
    }
}