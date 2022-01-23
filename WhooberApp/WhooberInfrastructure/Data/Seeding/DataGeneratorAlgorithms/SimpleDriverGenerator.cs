using System;
using WhooberCore.Domain.Entities;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAbstractions;

namespace WhooberInfrastructure.Data.Seeding.DataGeneratorAlgorithms
{
    public class SimpleDriverGenerator : IDriverGenerator
    {
        private static readonly string[] Names =
        {
            "Чумабой", "Сервер", "Мраз", "Сасун", "Домуллобобо", "Угли", "Омон", "Шаихулуд",
            "Аббосали", "Джонидеп", "Ыхвал", "Дилдобрек", "Нуриахмат", "Срапион", "Обидзода",
        };
        private static readonly Random Rnd = new Random();
        private static int _curNum = 0;

        public Driver Generate()
        {
            return new Driver(Names[Rnd.Next(0, Names.Length)], $"{_curNum++ :D11}");
        }
    }
}