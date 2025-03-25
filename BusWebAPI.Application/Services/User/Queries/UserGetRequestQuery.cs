using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.User.Queries
{
    public class UserGetRequestQuery : IRequest<Response<UserGetRequestQuery>>
    {
        public int Id { get; set; }
    }
}
