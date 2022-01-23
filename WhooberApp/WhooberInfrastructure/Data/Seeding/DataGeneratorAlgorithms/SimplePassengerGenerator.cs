using System;
using WhooberCore.Domain.Entities;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAbstractions;

namespace WhooberInfrastructure.Data.Seeding.DataGeneratorAlgorithms
{
    public class SimplePassengerGenerator : IPassengerGenerator
    {
        private const int MinCoord = -1000;
        private const int MaxCoord = 1000;
        private static readonly string[] Names =
        {
            "Артём", "Даня", "Гоша", "Вика", "Миша", "Ваня", "Максим", "Сергей",
            "Эдгар", "Дмитрий", "Александр", "Библетун", "Дина", "Денис", "Валера",
        };
        private static readonly Random Rnd = new Random();
        private static int _curNum = 0;

        public Passenger Generate()
        {
            return new Passenger(Names[Rnd.Next(0, Names.Length)], $"{_curNum++ :D11}")
            {
                Location = new Location(Rnd.Next(MinCoord, MaxCoord), Rnd.Next(MinCoord, MaxCoord)),
            };
        }
    }
}