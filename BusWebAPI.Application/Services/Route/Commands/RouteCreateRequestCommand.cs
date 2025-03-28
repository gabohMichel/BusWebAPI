using MediatR;

namespace BusWebAPI.Application.Services.Route.Commands
{
    public class RouteCreateRequestCommand : IRequest
    {
        public string? DeparturePoint { get; set; }
        public string? ArrivingPoint { get; set; }
        public float Distance { get; set; }
    }
}
