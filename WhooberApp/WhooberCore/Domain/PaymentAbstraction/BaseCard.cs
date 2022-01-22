using System;

namespace WhooberCore.Domain.PaymentAbstraction
{
    public abstract class BaseCard
    {
        protected BaseCard(string number)
        {
            CardNumber = number ?? throw new ArgumentNullException(nameof(number));
        }

        public string CardNumber { get; private init; }

        public abstract void Pay(decimal sumToPay);
        public abstract void Receive(decimal sumToReceive);
        public abstract bool HasEnoughMoney(decimal sumToPay);
    }
}