using System;
using WhooberCore.Payment;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAbstractions;

namespace WhooberInfrastructure.Data.Seeding.DataGeneratorAlgorithms
{
    public class SimpleCardGenerator : ICardGenerator
    {
        private const int MinBalance = 0;
        private const int MaxBalance = 1000000;
        private static readonly Random Rnd = new Random();
        private static int _curNum = 0;

        public DummyCard Generate()
        {
            var card = new DummyCard($"{_curNum++ :D16}")
            {
                Balance = Rnd.Next(MinBalance, MaxBalance),
            };

            return card;
        }
    }
}