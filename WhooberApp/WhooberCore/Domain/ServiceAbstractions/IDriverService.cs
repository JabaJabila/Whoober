using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IDriverService : IBaseService
    {
        void RegisterDriver(Driver driver);
        void SetDriverStateToWorking(Driver driver);
        void SetDriverStateToInactive(Driver driver);
        void SetDriverStateToWaiting(Driver driver);
        void AcceptOrder(Driver driver, Order order);
        void ChangeTripStateToAwaitDriver(Driver driver);
        void ChangeTripStateToAwaitClient(Driver driver);
        void ChangeTripStateToOnTheWay(Driver driver);
        void ChangeTripStateToFinished(Driver driver);
        IReadOnlyCollection<Driver> GetActiveDrivers();
    }
}