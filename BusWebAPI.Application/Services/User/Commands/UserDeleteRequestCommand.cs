using MediatR;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserDeleteRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
