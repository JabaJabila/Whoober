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
        bool ChangeTripState(TripState state);
        IReadOnlyCollection<Driver> GetActiveDrivers();
    }
}