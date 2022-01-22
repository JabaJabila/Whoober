using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IDriverService
    {
        Driver RegisterDriver(Driver driver);
        void SetDriverStateToWorking(Driver driver);
        void SetDriverStateToInactive(Driver driver);
        void SetDriverStateToWaiting(Driver driver);
    }
}