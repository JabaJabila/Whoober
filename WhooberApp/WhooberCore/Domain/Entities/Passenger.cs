using System;
using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Domain.Entities
{
    public class Passenger
    {
        public Passenger(string name, string phoneNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Rating = new Rating();
        }

        private Passenger()
        {
        }

        public Guid Id { get; private init; }
        public string Name { get; set; }
        public Rating Rating { get; private init; }
        public IPaymentMethod PaymentMethod { get; set; }
        public string PhoneNumber { get; private set; }
    }
}