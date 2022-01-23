using System;
using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Payment
{
    public class DummyCard : BaseCard
    {
        public DummyCard(string cardNumber)
            : base(cardNumber)
        {
            Balance = 0;
        }

        public decimal Balance { get; set; }
        public override void Pay(decimal sumToPay)
        {
            Balance -= sumToPay;
        }

        public override void Receive(decimal sumToReceive)
        {
            Balance += sumToReceive;
        }

        public override bool HasEnoughMoney(decimal sumToPay)
        {
            return Balance >= sumToPay;
        }
    }
}