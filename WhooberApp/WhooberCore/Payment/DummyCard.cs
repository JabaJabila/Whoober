using System;
using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Payment
{
    public class DummyCard : BaseCard
    {
        public DummyCard(string cardNumber, decimal initialBalance = 0)
            : base(cardNumber)
        {
            Balance = initialBalance;
        }

        public DummyCard()
            : base(null)
        {
        }

        public decimal Balance { get; private set; }
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