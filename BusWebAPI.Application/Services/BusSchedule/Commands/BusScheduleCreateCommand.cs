using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Models;
using MediatR;

namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleCreateCommand : IRequestHandler<BusScheduleCreateRequestCommand>
    {
        private readonly IBusScheduleRepository _busScheduleRepository;

        public BusScheduleCreateCommand(IBusScheduleRepository busScheduleRepository)
        {
            _busScheduleRepository = busScheduleRepository;
        }

        public async Task Handle(BusScheduleCreateRequestCommand request, CancellationToken cancellationToken)
        {
            var lBusSchedule = await _busScheduleRepository
                .GetList(
                idBus: request.IdBus, 
                departureTime: request.DepartureTime, 
                arrivingTime: request.ArrivingTime, 
                castDateTimeToDate: true,
                isAvailable: true
                );

            if (lBusSchedule.Any())
                throw new BadRequestException("Bus already has trip for those dates");

            var bs = await _busScheduleRepository.Create(new TabBusSchedule()
            {
                DepartureTime = request.DepartureTime,
                ArrivingTime = request.ArrivingTime,
                IsAvailable = request.IsAvailable,
                IdBus = request.IdBus,
                IdRoute = request.IdRoute,
            });

            if (bs == null || bs.Id == 0)
                throw new BadRequestException("record was not inserted successfully");
        }
    }
}
