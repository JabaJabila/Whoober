using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IServiceMediator
    {
        IReadOnlyCollection<Driver> GetActiveDriversByCarLevel(CarLevel carLevel);
        Trip ConfirmOrder(Order order, Driver driver);
    }
}