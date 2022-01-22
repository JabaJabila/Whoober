using System;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.Entities
{
    public class OrderRequest
    {
        public OrderRequest(Passenger passenger, Route route, CarLevel carLevel)
        {
            Passenger = passenger ?? throw new ArgumentNullException(nameof(passenger));
            Route = route ?? throw new ArgumentNullException(nameof(route));
            CarLevel = carLevel;
        }

        public Passenger Passenger { get; private init; }
        public Route Route { get; private init; }
        public CarLevel CarLevel { get; private init; }
    }
}