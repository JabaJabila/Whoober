using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface ITripService
    {
        Trip CreateTrip(Order order, Driver driver);
        void ChangeTripState(Trip trip, TripState state);
    }
}