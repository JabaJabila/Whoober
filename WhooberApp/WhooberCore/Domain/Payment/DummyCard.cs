using System;
using WhooberCore.Domain.Entities.PaymentAbstraction;

namespace WhooberCore.Domain.Payment
{
    public class DummyCard : ICard
    {
        public DummyCard(string cardNumber)
        {
            CardNumber = cardNumber ?? throw new ArgumentNullException(nameof(cardNumber));
        }

        public string CardNumber { get; set; }

        public void Pay(decimal sumToPay)
        {
        }

        public void Receive(decimal sumToReceive)
        {
        }

        public bool HasEnoughMoney(decimal sumToPay)
        {
            return true;
        }
    }
}