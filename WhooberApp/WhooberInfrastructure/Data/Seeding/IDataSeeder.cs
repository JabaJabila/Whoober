using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Payment;

namespace WhooberInfrastructure.Data.Seeding
{
    public interface IDataSeeder
    {
        IReadOnlyCollection<Passenger> GeneratePassengers(int count);
        IReadOnlyCollection<Car> GenerateCars(int count);
        IReadOnlyCollection<Driver> GenerateDrivers(int count);
        IReadOnlyCollection<DummyCard> GenerateCards(int count);
    }
}