using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.AlgorithmsAbstractions
{
    public interface IRouteLengthDeterminer
    {
        double CountLength(Route route);
    }
}