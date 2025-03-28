using BusWebAPI.Domain.Common;
using BusWebAPI.Application.Services.Bus.Queries;
using Microsoft.AspNetCore.Mvc;
using BusWebAPI.Application.Services.Bus.Commands;
using Microsoft.AspNetCore.Authorization;
using MediatR;

namespace BusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<Response<BusGetResponseQuery>> GetBus([FromRoute]BusGetRequestQuery request)
        {
            return await _mediator.Send(request);
        }
        [HttpGet]
        public async Task<Response<List<BusGetListResponseQuery>>> GetBuses()
        {
            return await _mediator.Send(new BusGetListRequestQuery());
        }
        [HttpPost]
        public async Task CreateBus([FromBody] BusCreateRequestCommand request)
        {
            await _mediator.Send(request);
        }
        [HttpPut("status")]
        public async Task UpdateBus([FromBody] BusUpdateRequestCommand request)
        {
            await _mediator.Send(request);
        }
        [HttpDelete("{Id}")]
        public async Task DeleteBus([FromRoute] BusDeleteRequestCommand request)
        {
            await _mediator.Send(request);
        }
    }
}
