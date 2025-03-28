using MediatR;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserUpdateRequestCommand : IRequest
    {
        public string? Username { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
