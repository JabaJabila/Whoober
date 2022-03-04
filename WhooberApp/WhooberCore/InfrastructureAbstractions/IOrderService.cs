using WhooberCore.Domain.Entities;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IOrderService : IBaseService
    {
        decimal RequestTripCost(OrderRequest orderRequest);
        Trip ApproveOrder(Order order);
    }
}