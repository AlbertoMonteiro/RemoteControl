using System.Data.Entity;
using RemoteControl.Core.Models;

namespace RemoteControl.Data
{
    internal sealed class RemoteControlContext : DbContext, IRemoteControlContext
    {
        public DbSet<Machine> Machines { get; set; }
    }
}
