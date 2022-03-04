using System;
using WhooberCore.Domain.Entities;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAbstractions;

namespace WhooberInfrastructure.Data.Seeding.DataGeneratorAlgorithms
{
    public class SimpleDriverGenerator : IDriverGenerator
    {
        private const int MinCoord = -1000;
        private const int MaxCoord = 1000;
        private static readonly string[] Names =
        {
            "Чумабой", "Сервер", "Мраз", "Сасун", "Домуллобобо", "Угли", "Омон", "Шаихулуд",
            "Аббосали", "Джонидеп", "Ыхвал", "Дилдобрек", "Нуриахмат", "Срапион", "Обидзода",
        };
        private static readonly Random Rnd = new Random();
        private static int _curNum = 0;

        public Driver Generate()
        {
            return new Driver(Names[Rnd.Next(0, Names.Length)], $"{_curNum++ :D11}")
            {
                Location = new Location(Rnd.Next(MinCoord, MaxCoord), Rnd.Next(MinCoord, MaxCoord)),
            };
        }
    }
}