using MediatR;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserUpdateCommand : IRequest
    {
        public string? Password { get; set; }
        public bool IsAdmin {  get; set; }
    }
}
