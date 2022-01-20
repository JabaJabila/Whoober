using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IDriverFinder
    {
        Driver FindDriver(Order order);
    }
}