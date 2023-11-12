using Microsoft.AspNetCore.SignalR;

namespace API_DACN.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string name, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", name, message);
            //Clients.Clients()
        }
        public override Task OnConnectedAsync()
        {
            string connectId = Context.ConnectionId;
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string connectId = Context.ConnectionId;
            return base.OnDisconnectedAsync(exception);
        }
    }
}
