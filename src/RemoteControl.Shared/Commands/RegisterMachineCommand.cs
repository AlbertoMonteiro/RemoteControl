using MediatR;

namespace RemoteControl.Shared.Commands
{
    public sealed class RegisterMachineCommand : IRequest<object>
    {
        public string MachineName { get; set; }
    }
}
