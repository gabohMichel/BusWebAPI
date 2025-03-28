using BusWebAPI.Application.Services.BusSchedule.Commands;
using BusWebAPI.Application.Services.BusSchedule.Queries;
using BusWebAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<Response<BusScheduleGetResponseQuery>> Get([FromRoute]BusScheduleGetRequestQuery request)
        {
            return await _mediator.Send(request);
        }
        [HttpGet]
        public async Task<Response<List<BusScheduleGetListResposeQuery>>> GetList([FromQuery]BusScheduleGetListRequestQuery request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost]
        public async Task Create([FromBody]BusScheduleCreateRequestCommand request)
        {
            await _mediator.Send(request);
        }
        [HttpPut]
        public async Task Update([FromBody] BusScheduleCreateRequestCommand request)
        {
            await _mediator.Send(request);
        }
        [HttpDelete("{Id}")]
        public async Task Delete([FromBody] BusScheduleCreateRequestCommand request)
        {
            await _mediator.Send(request);
        }
    }
}
