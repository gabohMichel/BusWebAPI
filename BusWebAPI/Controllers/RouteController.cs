using BusWebAPI.Application.Services.Route.Commands;
using BusWebAPI.Application.Services.Route.Queries;
using BusWebAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RouteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<Response<RouteGetResponseQuery>> Get([FromRoute]RouteGetRequestQuery request)
        {
            return await _mediator.Send(request);
        }
        [HttpGet]
        public async Task<Response<List<RouteGetListResponseQuery>>> GetList([FromQuery]RouteGetListRequestQuery request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task Create([FromBody]RouteCreateRequestCommand request)
        {
            await _mediator.Send(request);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task Update([FromBody] RouteUpdateRequestCommand request)
        {
            await _mediator.Send(request);
        }
        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task Delete([FromBody] RouteDeleteRequestCommand request)
        {
            await _mediator.Send(request);
        }
    }
}
