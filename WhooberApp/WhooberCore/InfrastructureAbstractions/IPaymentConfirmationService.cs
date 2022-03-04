using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IPaymentConfirmationService : IBaseService
    {
        bool ConfirmPayment(PaymentMethod method, decimal price);
    }
}