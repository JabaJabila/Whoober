using System;
using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.Entities;
using WhooberCore.Payment;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAbstractions;

namespace WhooberInfrastructure.Data.Seeding
{
    public class SimpleDataSeeder : IDataSeeder
    {
        private readonly IPassengerGenerator _passengerGenerator;
        private readonly IDriverGenerator _driverGenerator;
        private readonly ICarGenerator _carGenerator;
        private readonly ICardGenerator _cardGenerator;

        public SimpleDataSeeder(
            IPassengerGenerator passengerGenerator,
            IDriverGenerator driverGenerator,
            ICarGenerator carGenerator,
            ICardGenerator cardGenerator)
        {
            _passengerGenerator = passengerGenerator ?? throw new ArgumentNullException(nameof(passengerGenerator));
            _driverGenerator = driverGenerator ?? throw new ArgumentNullException(nameof(driverGenerator));
            _carGenerator = carGenerator ?? throw new ArgumentNullException(nameof(carGenerator));
            _cardGenerator = cardGenerator ?? throw new ArgumentNullException(nameof(cardGenerator));
        }

        public IReadOnlyCollection<Passenger> GeneratePassengers(int count)
        {
            var cardList = GenerateCards(count).ToList();
            var passengersList = new List<Passenger>();
            cardList.ForEach(c =>
            {
                Passenger passenger = _passengerGenerator.Generate();
                passenger.SavedCard = c;
                passengersList.Add(passenger);
            });

            return passengersList;
        }

        public IReadOnlyCollection<Car> GenerateCars(int count)
        {
            var carsList = new List<Car>();
            for (int counter = 0; counter < count; counter++)
                carsList.Add(_carGenerator.Generate());

            return carsList;
        }

        public IReadOnlyCollection<Driver> GenerateDrivers(int count)
        {
            var cardList = GenerateCards(count).ToList();
            var driversList = new List<Driver>();
            cardList.ForEach(c =>
            {
                Driver driver = _driverGenerator.Generate();
                driver.SavedCard = c;
                driver.Car = _carGenerator.Generate();
                driversList.Add(driver);
            });

            return driversList;
        }

        public IReadOnlyCollection<DummyCard> GenerateCards(int count)
        {
            var cardsList = new List<DummyCard>();
            for (int counter = 0; counter < count; counter++)
                cardsList.Add(_cardGenerator.Generate());

            return cardsList;
        }
    }
}