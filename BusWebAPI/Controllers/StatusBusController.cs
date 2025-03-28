using BusWebAPI.Application.Services.StatusBus.Queries;
using BusWebAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusBusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatusBusController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<Response<List<StatusBusGetListResponseQuery>>> GetList()
        {
            return await _mediator.Send(new StatusBusGetListRequestQuery());
        }
    }
}
