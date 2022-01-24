using WhooberCore.Domain.Enums;
using WhooberCore.Domain.PaymentAbstraction;

namespace Whoober_WebApplication.Models
{
    public class DriverMutableDto
    {
        public CarLevel Level { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string CarNumber { get; set; }
        public BaseCard SavedCard { get; set; }
    }
}