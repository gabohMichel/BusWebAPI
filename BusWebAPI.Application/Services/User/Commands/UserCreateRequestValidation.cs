using BusWebAPI.Application.CustomValidations;
using FluentValidation;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserCreateRequestValidation : AbstractValidator<UserCreateRequestCommand>
    {
        private IsNullOrEmpty _isNullOrEmpty;
        public UserCreateRequestValidation(ICustomValidation customValidation)
        {
            _isNullOrEmpty = (IsNullOrEmpty)customValidation;
            RuleFor(o => o.Username).Must(_isNullOrEmpty.IsValid).WithMessage("Field is required")
                .MaximumLength(50);
            RuleFor(o => o.Password).Must(_isNullOrEmpty.IsValid).WithMessage("Field is required")
                .MinimumLength(12)
                .Matches("[A-Z]").WithMessage("Field must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("Field must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("Field must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("Field must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("Field must not contain the following characters £ # “” or spaces.");
        }
    }
}
