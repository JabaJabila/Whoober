using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Payment;

namespace WhooberInfrastructure.Data.Seeding
{
    public class EmptySeeder : IDataSeeder
    {
        public IReadOnlyCollection<Passenger> GeneratePassengers(int count)
        {
            return new List<Passenger>();
        }

        public IReadOnlyCollection<Car> GenerateCars(int count)
        {
            return new List<Car>();
        }

        public IReadOnlyCollection<Driver> GenerateDrivers(int count)
        {
            return new List<Driver>();
        }

        public IReadOnlyCollection<DummyCard> GenerateCards(int count)
        {
            return new List<DummyCard>();
        }
    }
}