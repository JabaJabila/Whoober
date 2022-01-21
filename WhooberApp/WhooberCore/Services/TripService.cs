using WhooberCore.Domain.Entities;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class TripService : ITripService
    {
        public Trip CreateTrip(Order order, Driver driver)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeTripState(Trip trip)
        {
            throw new System.NotImplementedException();
        }
    }
}