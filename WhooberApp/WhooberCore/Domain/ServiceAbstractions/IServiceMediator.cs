using System.Collections.Generic;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IServiceMediator
    {
        IReadOnlyCollection<Driver> GetActiveDrivers();
    }
}