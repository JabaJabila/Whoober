namespace WhooberCore.Domain.PaymentAbstraction
{
    public interface IPaymentMethod
    {
        bool Pay(decimal sumToPay);
        bool Receive(decimal sumToReceive);
    }
}