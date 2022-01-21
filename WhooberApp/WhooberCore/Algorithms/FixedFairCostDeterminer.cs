using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.AlgoritmsAbstractions;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Algorithms
{
    public class FixedFairCostDeterminer : ICostDeterminer
    {
        private decimal _costPerDistanceUnit;
        private IRouteLengthDeterminer _routeLengthDeterminer;
        public FixedFairCostDeterminer(decimal costPerDistanceUnit, IRouteLengthDeterminer routeLengthDeterminer)
        {
            _costPerDistanceUnit = costPerDistanceUnit;
            _routeLengthDeterminer = routeLengthDeterminer;
        }

        public decimal DefineTripCost(OrderRequest orderRequest)
        {
            return _costPerDistanceUnit * (decimal)_routeLengthDeterminer.CountLength(orderRequest.Route) * (decimal)orderRequest.CarLevel;
        }
    }
}