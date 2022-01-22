using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface ITripService : IBaseService
    {
        Trip CreateTrip(Order order, Driver driver);
        void ChangeTripState(Trip trip, TripState state);
        TripState GetTripState(Trip trip);
    }
}