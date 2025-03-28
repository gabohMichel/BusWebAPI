using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using MediatR;

namespace BusWebAPI.Application.Services.Route.Commands
{
    public class RouteDeleteCommand : IRequestHandler<RouteDeleteRequestCommand>
    {
        private readonly IRouteRepository _routeRepository;

        public RouteDeleteCommand(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task Handle(RouteDeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var affected = await _routeRepository.Delete(request.Id);
            if (!affected)
                throw new NotFoundException("Route","id");
        }
    }
}
