using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Application.Utility;
using BusWebAPI.Domain.Models;
using MediatR;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserUpdateCommand : IRequestHandler<UserUpdateRequestCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncDecString _encDecString;
        public UserUpdateCommand(IUserRepository userRepository, IEncDecString encDecString)
        {
            _userRepository = userRepository;
            _encDecString = encDecString;
        }
        public async Task Handle(UserUpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var u = await _userRepository.Get(request.Username, _encDecString.EncString(request.OldPassword));
            if (u == null || u.Id == 0)
                throw new BadRequestException("User Name or Old Password no match");
            var affected = await _userRepository.Update(new TabUser() { Id = u.Id, Password = _encDecString.EncString(request.NewPassword) });

            if (!affected)
                throw new NotFoundException("User", "id");
        }
    }
}
