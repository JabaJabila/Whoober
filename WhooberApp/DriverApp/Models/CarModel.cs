using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace DriverApp.Models
{
    public class CarModel
    {
        public CarModel(Car car)
        {
            Level = car.Level;
            Model = car.Model;
            Color = car.Color;
            Number = car.Number;
        }
        public CarLevel Level { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
    }
}