using FluentValidation;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserDeleteRequestValidation : AbstractValidator<UserDeleteRequestCommand>
    {
        public UserDeleteRequestValidation() 
        {
            RuleFor(o => o.Id).NotNull().NotEmpty().NotEqual(0);
        }
    }
}
