using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JusTeeth.App.Hubs
{
    [HubName("chat")]
    public class MessageSender: Hub
    {
        public void SendMessage(string message)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);
            Clients.All.addMessage(msg);
        }

        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
            Clients.Caller.joinRoom(room);
        }

        public void SendMessageToRoom(string message, string room)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);
            Clients.Group(room).addMessage(msg);
        }
    }
}