using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Demo
{
    public class CommunicationHub :Hub
{
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "grp1");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "grp1");
        }

        public async Task BroadcastMessage(string msg)
        {
            await Clients.OthersInGroup("grp1").SendAsync("RecieveMessage", msg);

        }
    }
}
