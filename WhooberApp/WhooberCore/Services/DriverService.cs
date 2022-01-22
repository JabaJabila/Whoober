using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class DriverService : IDriverService
    {
        public void SetDriverStateToWorking(Driver driver)
        {
            driver.State = DriverState.Driving;
        }

        public void SetDriverStateToInactive(Driver driver)
        {
            driver.State = DriverState.Inactive;
        }

        public void SetDriverStateToWaiting(Driver driver)
        {
            driver.State = DriverState.Waiting;
        }
    }
}