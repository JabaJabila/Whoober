using System.Collections.Generic;
using System.Linq;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Algorithms
{
    public class DriverFinder : IDriverFinder
    {
        public Driver FindDriver(Order order, IReadOnlyCollection<Driver> activeDrivers)
        {
            // TODO async
            return activeDrivers.FirstOrDefault();
        }
    }
}