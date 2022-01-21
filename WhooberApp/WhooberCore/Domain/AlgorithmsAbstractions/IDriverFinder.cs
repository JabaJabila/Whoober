using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.AlgoritmsAbstractions
{
    public interface IDriverFinder
    {
        Driver FindDriver(Order order);
    }
}