using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RemoteControl.Core.Models;
using RemoteControl.Core.Repositories;
using RemoteControl.Shared.Commands;

namespace RemoteControl.Core.Handlers
{
    internal sealed class RegisterMachineCommandHandler : IRequestHandler<RegisterMachineCommand, object>
    {
        private readonly IMachineRepository _machineRepository;

        public RegisterMachineCommandHandler(IMachineRepository machineRepository)
            => _machineRepository = machineRepository;

        public async Task<object> Handle(RegisterMachineCommand request, CancellationToken cancellationToken)
        {
            var existsByMachineName = await _machineRepository.ExistsByMachineName(request.MachineName);
            if (existsByMachineName)
                return new Exception("There is machine with this name already");

            await _machineRepository.Include(new Machine(request.MachineName));

            return true;
        }
    }
}
