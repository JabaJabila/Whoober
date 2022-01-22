namespace WhooberCore.Domain.PaymentAbstraction
{
    public abstract class PaymentMethod
    {
        protected PaymentMethod()
        {
        }

        public abstract bool Pay(decimal sumToPay);
        public abstract bool Receive(decimal sumToReceive);
    }
}