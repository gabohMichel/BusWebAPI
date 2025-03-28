using BusWebAPI.Application.CustomValidations;
using FluentValidation;

namespace BusWebAPI.Application.Services.User.Commands
{
    public class UserUpdateRequestValidation : AbstractValidator<UserUpdateRequestCommand>
    {
        private IsNullOrEmpty _isNullOrEmpty;
        public UserUpdateRequestValidation(ICustomValidation customValidation)
        {
            _isNullOrEmpty = (IsNullOrEmpty)customValidation;
            RuleFor(o => o.Username).Must(_isNullOrEmpty.IsValid).WithMessage("Field is required");
            RuleFor(o => o.OldPassword).Must(_isNullOrEmpty.IsValid).WithMessage("Field is required");
            RuleFor(o => o.NewPassword).Must(_isNullOrEmpty.IsValid).WithMessage("Field is required")
                .MinimumLength(12)
                .Matches("[A-Z]").WithMessage("Field must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("Field must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("Field must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("Field must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("Field must not contain the following characters £ # “” or spaces.");
        }
    }
}
