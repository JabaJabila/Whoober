namespace WhooberCore.Domain.Entities.PaymentAbstraction
{
    public interface IPaymentMethod
    {
        bool Pay(decimal sumToPay);
        bool Receive(decimal sumToReceive);
    }
}