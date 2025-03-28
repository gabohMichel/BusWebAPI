using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Route.Queries
{
   public class RouteGetQuery : IRequestHandler<RouteGetRequestQuery, Response<RouteGetResponseQuery>>
   {
       private readonly IRouteRepository _routeRepository;
   
       public RouteGetQuery(IRouteRepository routeRepository)
       {
           _routeRepository = routeRepository;
       }
   
       public async Task<Response<RouteGetResponseQuery>> Handle(RouteGetRequestQuery request, CancellationToken cancellationToken)
       {
           var r = await _routeRepository.Get(request.Id);
            if (r == null || r.Id == 0)
                throw new NotFoundException("Route", "id");
           return new Response<RouteGetResponseQuery> 
           {
                Data = new RouteGetResponseQuery
                {
                    Id = r.Id,
                    DeparturePoint = r.DeparturePoint,
                    ArrivingPoint = r.ArrivingPoint,
                    Distance = r.Distance,
                },
                StatusCode = 200
           };
       }
   }
}
