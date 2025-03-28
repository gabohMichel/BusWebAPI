using BusWebAPI.Application.Services.User.Commands;
using BusWebAPI.Application.Services.User.Queries;
using BusWebAPI.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task CreateUser([FromBody]UserCreateRequestCommand request)
        {
            await _mediator.Send(request);
        }
        [HttpPut("password")]
        public async Task UpdatePasswordUser([FromBody]UserUpdateRequestCommand request)
        {
            await _mediator.Send(request);
        }
        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteUser([FromRoute] UserDeleteRequestCommand request)
        {
            await _mediator.Send(request);
        }
    }
}
