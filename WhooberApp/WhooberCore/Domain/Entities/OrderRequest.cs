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

        public Passenger Passenger { get; set; }
        public Route Route { get; set; }
        public CarLevel CarLevel { get; set; }
    }
}