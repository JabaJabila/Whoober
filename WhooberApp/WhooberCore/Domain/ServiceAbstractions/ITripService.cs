using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface ITripService
    {
        Trip CreateTrip(Order order, Driver driver);
        void ChangeTripState(Trip trip);
    }
}