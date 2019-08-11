using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace BookExchange.Infrastructure.Messages 
{
    public class StronglyTypedChatHub : Hub<IChatClient>
    {
        public async Task SendMessage (Reading reading) 
        {
            await Clients.All.ReceiveMessage (reading.Id, reading.BaseId, reading.Frequency, reading.Modulation, reading.Agc1, reading.Agc2, reading.TimeStamp);
        }

        // public override async Task OnConnectedAsync () 
        // {
        //     await base.OnConnectedAsync ();
        // }

        // public override async Task OnDisconnectedAsync (Exception exception) 
        // {
        //     await base.OnDisconnectedAsync (exception);
        // }
    }
}