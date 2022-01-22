using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IOrderService : IBaseService
    {
        decimal RequestTripCost(OrderRequest orderRequest);
        Trip ApproveOrder(Order order);
    }
}