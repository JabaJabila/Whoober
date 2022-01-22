namespace WhooberCore.Domain.PaymentAbstraction
{
    public interface ICard
    {
        void Pay(decimal sumToPay);
        void Receive(decimal sumToReceive);
        bool HasEnoughMoney(decimal sumToPay);
    }
}