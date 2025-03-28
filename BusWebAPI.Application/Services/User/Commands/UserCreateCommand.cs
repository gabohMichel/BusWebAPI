using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Application.Utility;
using BusWebAPI.Domain.Models;
using MediatR;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserCreateCommand : IRequestHandler<UserCreateRequestCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncDecString _encDecString;
        public UserCreateCommand(IUserRepository userRepository, IEncDecString encDecString)
        {
            _userRepository = userRepository;
            _encDecString = encDecString;
        }
        public async Task Handle(UserCreateRequestCommand request, CancellationToken cancellationToken)
        {
            var tmpUser = await _userRepository.Create(new TabUser()
            {
                UserName = request.Username,
                Password = _encDecString.EncString(request.Password),
                IsAdmin = request.IsAdmin,
            });

            if (tmpUser == null || tmpUser.Id == 0)
                throw new BadRequestException($"{nameof(UserCreateCommand)} - Record was not inserted correctly");
        }
    }
}
