using System.Collections.Generic;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.AlgorithmsAbstractions
{
    public interface IDriverFinder
    {
        Driver FindDriver(Order order, IReadOnlyCollection<Driver> activeDrivers);
    }
}