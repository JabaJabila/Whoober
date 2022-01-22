using System;
using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Payment
{
    public class CardMethod : IPaymentMethod
    {
        public CardMethod(ICard card)
        {
            Card = card ?? throw new ArgumentNullException(nameof(card));
        }

        public ICard Card { get; set; }

        public bool Pay(decimal sumToPay)
        {
            if (Card.HasEnoughMoney(sumToPay))
            {
                Card.Pay(sumToPay);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Receive(decimal sumToReceive)
        {
            Card.Receive(sumToReceive);
            return true;
        }
    }
}