using System;
using WhooberCore.Domain.PaymentAbstraction;

namespace WhooberCore.Payment
{
    public class CardMethod : PaymentMethod
    {
        public CardMethod(BaseCard card)
        {
            Card = card ?? throw new ArgumentNullException(nameof(card));
        }

        public BaseCard Card { get; set; }

        public override bool Pay(decimal sumToPay)
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

        public override bool Receive(decimal sumToReceive)
        {
            Card.Receive(sumToReceive);
            return true;
        }

        public override string ToString()
        {
            return "Card";
        }
    }
}