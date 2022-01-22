using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface ITripService : IBaseService
    {
        Trip CreateTrip(Order order, Driver driver);
        void ChangeTripStateToAwaitDriver(Trip trip);
        void ChangeTripStateToAwaitClient(Trip trip);
        void ChangeTripStateToOnTheWay(Trip trip);
        void ChangeTripStateToFinished(Trip trip);
        TripState GetTripState(Trip trip);
        Trip GetActiveTripByDriver(Driver driver);
    }
}