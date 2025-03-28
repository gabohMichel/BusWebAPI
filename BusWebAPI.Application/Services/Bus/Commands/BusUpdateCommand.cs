using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Models;
using MediatR;

namespace BusWebAPI.Application.Services.Bus.Commands
{
    public class BusUpdateCommand : IRequestHandler<BusUpdateRequestCommand>
    {
        private readonly IBusRepository _busRepository;

        public BusUpdateCommand(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task Handle(BusUpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var affected = await _busRepository.Update(new TabBus()
            {
                Id = request.Id,
                IdStatusBus = request.IdStatus
            });

            if (!affected)
                throw new NotFoundException("Bus", "id");
        }
    }
}
