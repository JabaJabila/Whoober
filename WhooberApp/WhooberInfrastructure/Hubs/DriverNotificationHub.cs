using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WhooberCore.Domain.Entities;

namespace WhooberInfrastructure.Hubs
{
    public class DriverNotificationHub : Hub
    {
        public async Task Send(Order order)
        {
            await Clients.All.SendAsync("Send", order);
        }
    }
}