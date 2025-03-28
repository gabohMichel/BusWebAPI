using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Models;
using MediatR;

namespace BusWebAPI.Application.Services.Route.Commands
{
    public class RouteCreateCommand : IRequestHandler<RouteCreateRequestCommand>
    {
        private readonly IRouteRepository _routeRepository;

        public RouteCreateCommand(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task Handle(RouteCreateRequestCommand request, CancellationToken cancellationToken)
        {
            var r = await _routeRepository.Create(new TabRoute()
            {
                DeparturePoint = request.DeparturePoint,
                ArrivingPoint = request.ArrivingPoint,
                Distance = request.Distance,
            });

            if (r == null || r.Id == 0)
                throw new BadRequestException($"{nameof(RouteCreateCommand)} - Record was not inserted correctly");
        }
    }
}
