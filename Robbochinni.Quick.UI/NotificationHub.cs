using Microsoft.AspNetCore.SignalR;

namespace Robbochinni.Quick.UI
{
    public class NotificationHub : Hub
    {
        public async void Join(string userId)
        {
            await Groups.AddToGroupAsync(userId, "quick-drivers");
        }

        public async Task SendAsync(string notification)
        {
            await Clients.Group("quick-drivers").SendAsync("receive-notification", notification);
        }
    }
}
