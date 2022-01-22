using System.Collections.Generic;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Builders
{
    public class OrderRequestBuilder
    {
        private List<Location> _routePoints;
        private Passenger _passenger;
        private CarLevel _carLevel;
        public OrderRequestBuilder()
        {
            _routePoints = new List<Location>();
        }

        public OrderRequest ToOrderRequest()
        {
            return new OrderRequest(_passenger, new Route(_routePoints), _carLevel);
        }

        public OrderRequestBuilder SetPassenger(Passenger passenger)
        {
            _passenger = passenger;
            return this;
        }

        public OrderRequestBuilder SetCarLevel(CarLevel carLevel)
        {
            _carLevel = carLevel;
            return this;
        }

        public OrderRequestBuilder AddLocation(Location location)
        {
            _routePoints.Add(location);
            return this;
        }
    }
}