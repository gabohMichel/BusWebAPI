using MediatR;

namespace BusWebAPI.Application.Services.Route.Commands
{
    public class RouteDeleteRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
