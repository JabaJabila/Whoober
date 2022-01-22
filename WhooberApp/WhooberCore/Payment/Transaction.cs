using WhooberCore.Domain.Entities;
using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Payment
{
    public class Transaction
    {
        private PaymentMethod _paymentMethod;
        public Transaction(PaymentMethod paymentMethod, PaymentMethod receiveMethod, decimal price)
        {
            PaymentMethod = paymentMethod;
            ReceiveMethod = receiveMethod;
            Price = price;
        }

        public bool ExecuteTransaction()
        {
            if (!PaymentMethod.Pay(Price)) return false;
            ReceiveMethod.Receive(Price);
            return true;
        }

        public PaymentMethod PaymentMethod { get; private init; }
        public PaymentMethod ReceiveMethod { get; private init; }
        public decimal Price { get; private init; }
    }
}