using System;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAbstractions;

namespace WhooberInfrastructure.Data.Seeding.DataGeneratorAlgorithms
{
    public class SimpleCarGenerator : ICarGenerator
    {
        private static readonly string[] Colors = { "red", "gray", "white", "blue", "green", "brown" };
        private static readonly string[] CheapCars = { "Hyundai Solaris", "Volkswagen Polo", "Kia Rio", "Lada Vesta" };
        private static readonly string[] ComfortCars = { "Skoda Octavia", "Toyota Camry", "Kia Optima" };
        private static readonly string[] BusinessCars = { "Mercedes E", "Mercedes S", "Audi A8" };
        private static readonly string[] EliteCars = { "Mercedes Maybach S", "Bentley Flying Spur" };
        private static readonly string[] CargoCars = { "Citroen Jumpy", "Ford Transit" };
        private static readonly string[][] AllCars = { CheapCars, ComfortCars, BusinessCars, EliteCars, CargoCars, CheapCars };
        private static readonly int CountLevels = AllCars.Length;
        private static readonly Random Rnd = new Random();
        private static readonly string Letters = "авекмнорстух";
        private static int _curNum = 0;

        public Car Generate()
        {
            int num = Rnd.Next(0, CountLevels);
            var level = (CarLevel)num;
            _curNum %= 1000;
            return new Car(
                AllCars[num][Rnd.Next(0, AllCars[num].Length)],
                Colors[Rnd.Next(0, Colors.Length)],
                GenerateCarNumber(),
                level);
        }

        private string GenerateCarNumber()
        {
            return $"{Letters[Rnd.Next(0, Letters.Length)]}{_curNum++ :D3}" +
                   $"{Letters[Rnd.Next(0, Letters.Length)]}{Letters[Rnd.Next(0, Letters.Length)]}";
        }
    }
}