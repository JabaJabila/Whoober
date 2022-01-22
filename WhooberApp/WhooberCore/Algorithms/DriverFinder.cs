using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Algorithms
{
    public class DriverFinder : IDriverFinder
    {
        private readonly IDistanceDeterminer _distanceDeterminer;
        public DriverFinder(IDistanceDeterminer distanceDeterminer)
        {
            _distanceDeterminer = distanceDeterminer;
        }

        public Driver FindDriver(Order order, IReadOnlyCollection<Driver> activeDrivers)
        {
            // TODO find
            SortDriversByLocation(order.Route.Start, activeDrivers.ToList());
            return activeDrivers.FirstOrDefault();
        }

        private void SortDriversByLocation(Location start, List<Driver> activeDrivers)
        {
            activeDrivers.Sort((x, y) => (int)(_distanceDeterminer.CountLocationsDistance(start, x.Location) - _distanceDeterminer.CountLocationsDistance(start, y.Location)));
        }
    }
}