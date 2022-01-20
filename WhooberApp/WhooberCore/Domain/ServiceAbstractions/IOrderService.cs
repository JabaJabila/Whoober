using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IOrderService
    {
        decimal RequestTripCost(Order order);
        void ApproveOrder(Order order);
        void DenyOrder(Order order);
    }
}