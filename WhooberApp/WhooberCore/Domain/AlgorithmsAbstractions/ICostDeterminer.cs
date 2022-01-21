using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.AlgoritmsAbstractions
{
    public interface ICostDeterminer
    {
        decimal DefineTripCost(OrderRequest orderRequest);
    }
}