using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.AlgorithmsAbstractions
{
    public interface IDistanceDeterminer
    {
        double CountLength(Route route);
        double CountLocationsDistance(Location start, Location finish);
    }
}