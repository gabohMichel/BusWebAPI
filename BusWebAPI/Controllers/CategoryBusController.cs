using BusWebAPI.Application.Services.CategoryBus.Queries;
using BusWebAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryBusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryBusController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<Response<List<CategoryBusGetListResponseQuery>>> GetList()
        {
            return await _mediator.Send(new CategoryBusGetListRequestQuery());
        }
    }
}
