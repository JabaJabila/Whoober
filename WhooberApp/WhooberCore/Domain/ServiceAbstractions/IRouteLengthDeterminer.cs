using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IRouteLengthDeterminer
    {
        double CountLength(Route route);
    }
}