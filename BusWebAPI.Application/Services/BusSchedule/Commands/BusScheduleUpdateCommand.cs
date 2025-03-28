using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Models;
using MediatR;

namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleUpdateCommand : IRequestHandler<BusScheduleUpdateRequestCommand>
    {
        private readonly IBusScheduleRepository _busScheduleRepository;

        public BusScheduleUpdateCommand(IBusScheduleRepository busScheduleRepository)
        {
            _busScheduleRepository = busScheduleRepository;
        }

        public async Task Handle(BusScheduleUpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var lBusSchedule = await _busScheduleRepository
                .GetList(
                idBus: request.IdBus,
                departureTime: request.DepartureTime,
                arrivingTime: request.ArrivingTime,
                castDateTimeToDate: true,
                isAvailable: true,
                notContainsId: [(int)request.Id]
                );

            if (lBusSchedule.Any())
                throw new BadRequestException("Bus already has trip for those dates");

            var afffected = await _busScheduleRepository.Update(new TabBusSchedule()
            {
                ArrivingTime = request.ArrivingTime,
                DepartureTime = request.DepartureTime,
                
            });

            if (!afffected)
                throw new NotFoundException("Bus Schedule", "id");
        }
    }
}
