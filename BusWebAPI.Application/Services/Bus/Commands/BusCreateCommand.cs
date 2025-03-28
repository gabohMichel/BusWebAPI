using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Models;
using MediatR;

namespace BusWebAPI.Application.Services.Bus.Commands
{
    public class BusCreateCommand : IRequestHandler<BusCreateRequestCommand>
    {
        private readonly IBusRepository _busRepository;
        public BusCreateCommand(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }
        public async Task Handle(BusCreateRequestCommand request, CancellationToken cancellationToken)
        {
            var b = await _busRepository.Create(new TabBus()
            {
                Plates = request.Plates,
                Capacity = request.Capacity,
                IdStatusBus = request.IdStatusBus,
                IdCategory = request.IdCategory
            });

            if (b == null || b.Id == 0)
                throw new BadRequestException($"{nameof(BusCreateCommand)} - Record was not inserted correctly");
        }
    }
}
