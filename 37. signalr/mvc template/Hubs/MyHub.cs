using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace mvc_template.Hubs
{
    public class MyHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.newMessage(message);
        }
    }
}