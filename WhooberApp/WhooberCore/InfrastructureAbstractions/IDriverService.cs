using System;
using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Dto;
using WhooberCore.Models;

namespace WhooberCore.InfrastructureAbstractions
{
    public interface IDriverService : IBaseService
    {
        Driver RegisterDriver(Driver driver);
        bool UpdateLocation(Guid id, Location newLocation);
        Driver FindDriverById(Guid id);
        bool SetDriverStateToWorking(Guid id);
        bool SetDriverStateToInactive(Guid id);
        bool SetDriverStateToWaiting(Guid id);
        bool AcceptOrder(Guid id, Order order);
        bool DenyOrder(Guid id, Order order);
        bool ChangeTripStateToAwaitDriver(Guid id);
        bool ChangeTripStateToAwaitClient(Guid id);
        bool ChangeTripStateToOnTheWay(Guid id);
        bool ChangeTripStateToFinished(Guid id);
        Driver UpdateDriver(Guid id);
        IReadOnlyCollection<Driver> GetActiveDrivers();
    }
}