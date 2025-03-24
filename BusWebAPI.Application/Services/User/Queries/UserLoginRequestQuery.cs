using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.User.Queries
{
    public class UserLoginRequestQuery : IRequest<Response<UserLoginResponseQuery>>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
