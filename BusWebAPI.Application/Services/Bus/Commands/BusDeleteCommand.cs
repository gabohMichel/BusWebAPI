using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using MediatR;

namespace BusWebAPI.Application.Services.Bus.Commands
{
    public class BusDeleteCommand : IRequestHandler<BusDeleteRequestCommand>
    {
        private readonly IBusRepository _busRepository;

        public BusDeleteCommand(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task Handle(BusDeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var affected = await _busRepository.Delete((int)request.Id);
            if (!affected)
                throw new NotFoundException("Bus", "id");
        }
    }
}
