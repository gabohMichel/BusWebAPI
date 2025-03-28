using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Route.Queries
{
    public class RouteGetRequestQuery : IRequest<Response<RouteGetResponseQuery>>
    {
        public int Id { get; set; }
    }
}
