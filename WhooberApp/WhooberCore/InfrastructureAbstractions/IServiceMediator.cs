using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IServiceMediator
    {
        IReadOnlyCollection<Driver> GetActiveDriversByCarLevel(CarLevel carLevel);
        Trip ConfirmOrder(Order order, Driver driver);
        void ChangeTripStateToAwaitDriver(Trip trip);
        void ChangeTripStateToAwaitClient(Trip trip);
        void ChangeTripStateToOnTheWay(Trip trip);
        void ChangeTripStateToFinished(Trip trip);
        Trip FindActiveTripByDriver(Driver driver);
    }
}