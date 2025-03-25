using MediatR;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserCreateRequestCommand : IRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
