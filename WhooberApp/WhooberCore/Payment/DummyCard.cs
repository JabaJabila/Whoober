using System;
using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Payment
{
    public class DummyCard : BaseCard
    {
        public DummyCard(string cardNumber)
            : base(cardNumber)
        {
        }

        public override void Pay(decimal sumToPay)
        {
        }

        public override void Receive(decimal sumToReceive)
        {
        }

        public override bool HasEnoughMoney(decimal sumToPay)
        {
            return true;
        }
    }
}