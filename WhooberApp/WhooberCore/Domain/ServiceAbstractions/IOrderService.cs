using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IOrderService
    {
        decimal RequestTripCost(OrderRequest orderRequest);
        void ApproveOrder(Order order);
    }
}