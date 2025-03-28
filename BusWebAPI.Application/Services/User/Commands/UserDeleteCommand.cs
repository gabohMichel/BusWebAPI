using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using MediatR;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserDeleteCommand : IRequestHandler<UserDeleteRequestCommand>
    {
        private readonly IUserRepository _userRepository;
        public UserDeleteCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(UserDeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var affected = await _userRepository.Delete(request.Id);

            if (!affected)
                throw new NotFoundException("User", "id");
        }
    }
}
