using System.Collections.Generic;
using WhooberCore.Domain.AlgorithmsAbstractions;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.ServiceAbstractions;

namespace WhooberCore.Services
{
    public class ServiceMediator : IServiceMediator
    {
        private readonly IDriverService _driverService;
        public IReadOnlyCollection<Driver> GetActiveDrivers()
        {
            return _driverService.GetActiveDrivers();
        }
    }
}