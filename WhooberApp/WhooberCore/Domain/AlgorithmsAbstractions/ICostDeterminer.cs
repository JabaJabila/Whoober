using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.AlgorithmsAbstractions
{
    public interface ICostDeterminer
    {
        decimal DefineTripCost(OrderRequest orderRequest);
    }
}