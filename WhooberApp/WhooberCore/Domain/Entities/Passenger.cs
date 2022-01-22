using System;

namespace WhooberCore.Domain.Entities
{
    public class Passenger
    {
        public Passenger(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Rating = new Rating();
        }

        private Passenger()
        {
        }

        public Guid Id { get; private init; }
        public string Name { get; set; }
        public Rating Rating { get; private init; }
    }
}