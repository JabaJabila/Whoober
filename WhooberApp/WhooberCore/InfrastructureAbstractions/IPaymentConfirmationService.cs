using WhooberCore.Domain.PaymentAbstraction;
using WhooberCore.Payment;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IPaymentConfirmationService : IBaseService
    {
        bool ConfirmPayment(PaymentMethod method, decimal price);
    }
}