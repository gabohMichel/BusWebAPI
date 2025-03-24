using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Common;
using MediatR;
using System.Net;
using Newtonsoft.Json;

namespace BusWebAPI.Application.Services.User.Queries
{
    public class UserLoginQuery : IRequestHandler<UserLoginRequestQuery, Response<UserLoginResponseQuery>>
    {
        private readonly IUserRepository _userRepository;

        public UserLoginQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<UserLoginResponseQuery>> Handle(UserLoginRequestQuery request, CancellationToken cancellationToken)
        {
            var a = await _userRepository.GetUsers();
            if (!a.Any()) {
                return new Response<UserLoginResponseQuery>()
                {
                    Success = false,
                    Data = null,
                    StatusCode = (short)HttpStatusCode.NoContent
                };
            }
            return new Response<UserLoginResponseQuery>()
            {
                Success = true,
                Data = new UserLoginResponseQuery() { Token = JsonConvert.SerializeObject(a) },
                StatusCode = (short)HttpStatusCode.OK,
                Message = ""
            };
        }
    }
}
