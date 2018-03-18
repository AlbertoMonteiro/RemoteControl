using Microsoft.AspNet.SignalR;

namespace RemoteControl.Web.Hubs
{
    public class MachineHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}