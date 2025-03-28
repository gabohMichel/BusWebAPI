using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Route.Queries
{
    public class RouteGetListQuery : IRequestHandler<RouteGetListRequestQuery, Response<List<RouteGetListResponseQuery>>>
    {
        private readonly IRouteRepository _routeRepository;

        public RouteGetListQuery(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<Response<List<RouteGetListResponseQuery>>> Handle(RouteGetListRequestQuery request, CancellationToken cancellationToken)
        {
            var lTmp = await _routeRepository.GetList(request.DeparturePoint, request.ArrivingPoint);
            return new Response<List<RouteGetListResponseQuery>>
            {
                StatusCode = 200,
                Data = lTmp.Select(o => new RouteGetListResponseQuery()
                {
                    Id = o.Id,
                    ArrivingPoint = o.ArrivingPoint,
                    DeparturePoint = o.DeparturePoint,
                    Distance = o.Distance,
                }).ToList()
            };
        }
    }
}
