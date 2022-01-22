using System.Collections.Generic;
using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IDriverService
    {
        void RegisterDriver(Driver driver);
        void SetDriverStateToWorking(Driver driver);
        void SetDriverStateToInactive(Driver driver);
        void SetDriverStateToWaiting(Driver driver);
        void AcceptOrder(Driver driver, Order order);
        IReadOnlyCollection<Driver> GetActiveDrivers();
    }
}