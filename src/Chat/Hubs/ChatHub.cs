using Chat.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    [Authorize]
    public class ChatHub(AppDbContext context) : Hub
    {
        public override Task OnConnectedAsync()
        {
            
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
