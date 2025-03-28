using MediatR;

namespace BusWebAPI.Application.Services.Route.Commands
{
    public class RouteUpdateRequestCommand : IRequest
    {
        public int Id { get; set; }
        public double? Distance { get; set; }
    }
}
