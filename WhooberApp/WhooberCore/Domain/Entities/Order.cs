using System;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.Tools;

namespace WhooberCore.Domain.Entities
{
    public class Order
    {
        public Order(OrderRequest orderRequest, decimal price)
        {
            Passenger = orderRequest.Passenger;
            Route = orderRequest.Route;
            CarLevel = orderRequest.CarLevel;
            if (price < 0)
                throw new TripException("Price for order can't be < 0");
            Price = price;
        }

        public Order(Passenger passenger, Route route, CarLevel carLevel, decimal price)
        {
            Passenger = passenger ?? throw new ArgumentNullException(nameof(passenger));
            Route = route ?? throw new ArgumentNullException(nameof(route));
            CarLevel = carLevel;
            if (price < 0)
                throw new TripException("Price for order can't be < 0");

            Price = price;
            State = OrderState.AwaitApprove;
        }

        private Order()
        {
        }

        public Guid Id { get; private init; }
        public Passenger Passenger { get; private init; }
        public Route Route { get; private init; }
        public CarLevel CarLevel { get; private init; }
        public decimal Price { get; private init; }
        public OrderState State { get; set; }
    }
}