using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Common;
using MediatR;
using BusWebAPI.Application.Utility;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BusWebAPI.Application.Exceptions;

namespace BusWebAPI.Application.Services.User.Queries
{
    public class UserLoginQuery : IRequestHandler<UserLoginRequestQuery, Response<UserLoginResponseQuery>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncDecString _encDecString;
        private readonly IConfiguration _configuration;

        public UserLoginQuery(IUserRepository userRepository, IEncDecString encDecString, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _encDecString = encDecString;
            _configuration = configuration;
        }

        public async Task<Response<UserLoginResponseQuery>> Handle(UserLoginRequestQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Username, _encDecString.EncString(request.Password));
            if (user == null || user.Id == 0)
                throw new BadRequestException("Parameters not accepted");

            var claims = new[]
            {
                new Claim(ClaimTypes.UserData, user.Username),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "NonAdmin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("SigninKey").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenObj = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenObj);
            return new Response<UserLoginResponseQuery>()
            {
                StatusCode = 200,
                Data = new UserLoginResponseQuery() { Token = tokenString }
            };
        }
    }
}
