using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using MediatR;

namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleDeleteCommand : IRequestHandler<BusScheduleDeleteRequestCommand>
    {
        private readonly IBusScheduleRepository _busScheduleRepository;

        public BusScheduleDeleteCommand(IBusScheduleRepository busScheduleRepository)
        {
            _busScheduleRepository = busScheduleRepository;
        }

        public async Task Handle(BusScheduleDeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var affected = await _busScheduleRepository.Delete(request.Id);
            if (!affected)
                throw new NotFoundException("Bus Schedule","id");
        }
    }
}
