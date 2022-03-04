using WhooberCore.Domain.Entities;
using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Models
{
    public class DriverAdditionModel
    {
        public Car Car { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public BaseCard SavedCard { get; set; }
    }
}