using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Payment
{
    public class Transaction
    {
        public Transaction(PaymentMethod paymentMethod, PaymentMethod receiveMethod, decimal price)
        {
            PaymentMethod = paymentMethod;
            ReceiveMethod = receiveMethod;
            Price = price;
        }

        public PaymentMethod PaymentMethod { get; private init; }
        public PaymentMethod ReceiveMethod { get; private init; }
        public decimal Price { get; private init; }
        public bool ExecuteTransaction()
        {
            if (!PaymentMethod.Pay(Price)) return false;
            ReceiveMethod.Receive(Price);
            return true;
        }
    }
}