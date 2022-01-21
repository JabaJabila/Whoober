using WhooberCore.Domain.Entities;

namespace WhooberCore.Domain.ServiceAbstractions
{
    public interface IDriverService
    {
        void SetDriverStateToWorking(Driver driver);
        void SetDriverStateToInactive(Driver driver);
        void SetDriverStateToWaiting(Driver driver);
    }
}