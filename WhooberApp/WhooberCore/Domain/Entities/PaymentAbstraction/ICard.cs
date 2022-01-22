namespace WhooberCore.Domain.Entities.PaymentAbstraction
{
    public interface ICard
    {
        void Pay(decimal sumToPay);
        void Receive(decimal sumToReceive);
        bool HasEnoughMoney(decimal sumToPay);
    }
}