using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;
using WhooberCore.InfrastructureAbstractions;

namespace WhooberInfrastructure.Hubs
{
    public class DriverNotificationHub : Hub
    {
        private readonly IDriverService _driverService;

        public DriverNotificationHub(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task DriverPingMessage(string driverId, float latitude, float longitude, DriverState state)
        {
            _driverService.UpdateLocation(Guid.Parse(driverId), new Location(latitude, longitude));
            await Clients.All.SendAsync("DriverPing", Hash(driverId), latitude, longitude, state);
        }

        private string Hash(string driverId)
        {
            return driverId.Substring(16);
        }
    }
}