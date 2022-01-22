using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Payment
{
    public class CashPayment : IPaymentMethod
    {
        public bool Pay(decimal sumToPay)
        {
            return true;
        }

        public bool Receive(decimal sumToReceive)
        {
            return true;
        }
    }
}