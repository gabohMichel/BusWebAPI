using MediatR;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserCreateCommand : IRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
