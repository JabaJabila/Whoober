using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface ICostDeterminator
    {
        decimal DefineTripCost(Order order);
    }
}