using System;
using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IDriverService : IBaseService
    {
        void RegisterDriver(Driver driver);
        Driver FindDriverById(Guid id);
        void SetDriverStateToWorking(Guid id);
        void SetDriverStateToInactive(Guid id);
        void SetDriverStateToWaiting(Guid id);
        void AcceptOrder(Guid id, Order order);
        void ChangeTripStateToAwaitDriver(Guid id);
        void ChangeTripStateToAwaitClient(Guid id);
        void ChangeTripStateToOnTheWay(Guid id);
        void ChangeTripStateToFinished(Guid id);
        IReadOnlyCollection<Driver> GetActiveDrivers();
    }
}