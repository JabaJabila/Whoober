using System;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.Tools;

namespace WhooberCore.Domain.Entities
{
    public class Order
    {
        private decimal _price;
        public Guid Id { get; private init; }
        public Passenger Passenger { get; private init; }
        public Route Route { get; private init; }
        public CarLevel CarLevel { get; private init; }
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new TripException("Price for order can't be < 0");
                _price = value;
            }
        }

        public OrderState State { get; set; }

        public Order(Passenger passenger, Route route, CarLevel carLevel, decimal price)
        {
            Passenger = passenger ?? throw new ArgumentNullException(nameof(passenger));
            Route = route ?? throw new ArgumentNullException(nameof(route));
            CarLevel = carLevel;
            if (price < 0)
                throw new TripException("Price for order can't be < 0");

            _price = price;
            State = OrderState.AwaitApprove;
        }

        private Order()
        {
        }
    }
}