using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Algorithms
{
    public class FixedFairCostDeterminer : ICostDeterminer
    {
        private decimal _costPerDistanceUnit;
        private IDistanceDeterminer _distanceDeterminer;
        public FixedFairCostDeterminer(decimal costPerDistanceUnit, IDistanceDeterminer distanceDeterminer)
        {
            _costPerDistanceUnit = costPerDistanceUnit;
            _distanceDeterminer = distanceDeterminer;
        }

        public decimal DefineTripCost(OrderRequest orderRequest)
        {
            return _costPerDistanceUnit * (decimal)_distanceDeterminer.CountLength(orderRequest.Route) * (decimal)(1 + orderRequest.CarLevel);
        }
    }
}