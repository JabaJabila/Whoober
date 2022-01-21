using WhooberCore.Domain.Entities;
using WhooberCore.Domain.ServiceAbstractions;

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

        public decimal DefineTripCost(Order order)
        {
            return _costPerDistanceUnit * (decimal)_routeLengthDeterminer.CountLength(order.Route) * (decimal)order.CarLevel;
        }
    }
}