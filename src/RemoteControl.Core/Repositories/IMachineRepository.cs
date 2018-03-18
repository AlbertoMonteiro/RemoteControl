using System.Threading.Tasks;
using RemoteControl.Core.Handlers;
using RemoteControl.Core.Models;

namespace RemoteControl.Core.Repositories
{
    internal interface IMachineRepository
    {
        Task<bool> ExistsByMachineName(string machineName);
        Task Include(Machine machine);
    }
}