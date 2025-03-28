using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Route.Queries
{
    public class RouteGetListRequestQuery : IRequest<Response<List<RouteGetListResponseQuery>>>
    {
        public string? DeparturePoint { get; set; }
        public string? ArrivingPoint { get; set; }
    }
}
