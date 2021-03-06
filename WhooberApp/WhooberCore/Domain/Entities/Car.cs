using System;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.Entities
{
    public class Car
    {
        public Car(string model, string color, string number, CarLevel level)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Color = color ?? throw new ArgumentNullException(nameof(color));
            Number = number ?? throw new ArgumentNullException(nameof(number));
            Level = level;
        }

        private Car()
        {
        }

        public Guid Id { get; private init; }
        public CarLevel Level { get; init; }
        public string Model { get; private init; }
        public string Color { get; private init; }
        public string Number { get; private init; }

        public override string ToString()
        {
            return $"{Color} {Model} {Number}, class {Level}";
        }
    }
}