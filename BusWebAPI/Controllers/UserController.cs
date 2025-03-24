using BusWebAPI.Application.Services.User.Queries;
using BusWebAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMediator _mediator;
        public UserController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpGet("login/{Username}/{Password}")]
        public async Task<Response<UserLoginResponseQuery>> Login([FromRoute]UserLoginRequestQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
