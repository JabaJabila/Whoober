using System;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.Entities
{
    public class OrderRequest
    {
        public OrderRequest(Passenger passenger, Route route, CarLevel carLevel)
        {
            Passenger = passenger;
            Route = route;
            CarLevel = carLevel;
        }

        public Guid Id { get; private init; }
        public Passenger Passenger { get; private init; }
        public Route Route { get; private init; }
        public CarLevel CarLevel { get; private init; }
    }
}