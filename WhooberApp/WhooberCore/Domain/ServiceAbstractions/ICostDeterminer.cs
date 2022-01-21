using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface ICostDeterminer
    {
        decimal DefineTripCost(Order order);
    }
}