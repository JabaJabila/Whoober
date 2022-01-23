using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Payment
{
    public class CashPayment : PaymentMethod
    {
        public override bool Pay(decimal sumToPay)
        {
            return true;
        }

        public override bool Receive(decimal sumToReceive)
        {
            return true;
        }

        public override string ToString()
        {
            return "Cash";
        }
    }
}