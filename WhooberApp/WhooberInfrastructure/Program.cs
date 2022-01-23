using System;
using WhooberCore.Domain.Entities;
using WhooberCore.Payment;
using WhooberInfrastructure.Data.Seeding.DataGeneratorAlgorithms;

namespace WhooberInfrastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new SimplePassengerGenerator();
            for (int i = 0; i < 999; i++)
            {
                Passenger passenger = g.Generate();
                Console.WriteLine($"{passenger.Name}: {passenger.PhoneNumber}");
            }
        }
    }
}