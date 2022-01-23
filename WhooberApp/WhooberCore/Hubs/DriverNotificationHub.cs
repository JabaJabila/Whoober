using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WhooberCore.Hubs
{
    public class DriverNotificationHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}