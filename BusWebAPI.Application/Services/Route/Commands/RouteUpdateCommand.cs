using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Models;
using MediatR;

namespace BusWebAPI.Application.Services.Route.Commands
{
    public class RouteUpdateCommand : IRequestHandler<RouteUpdateRequestCommand>
    {
        private readonly IRouteRepository _routeRepository;

        public RouteUpdateCommand(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task Handle(RouteUpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var affected = await _routeRepository.Update(new TabRoute()
            {
                Id = request.Id,
                Distance = request.Distance,
            });
            if (!affected)
                throw new NotFoundException("Route", "id");
        }
    }
}
