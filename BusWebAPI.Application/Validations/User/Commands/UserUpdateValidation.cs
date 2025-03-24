using BusWebAPI.Application.CustomValidations;
using BusWebAPI.Application.Services.User.Commands;
using FluentValidation;

namespace BusWebAPI.Application.Validations.User.Commands
{
    public class UserUpdateValidation : AbstractValidator<UserUpdateCommand>
    {
        private IsNullOrEmpty _isNullOrEmpty;
        public UserUpdateValidation(ICustomValidation customValidation) 
        {
            _isNullOrEmpty = (IsNullOrEmpty)customValidation;
            RuleFor(o => o.Password).Must(_isNullOrEmpty.IsValid).WithMessage("'{PropertyName}' is required")
                .MinimumLength(12)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{ PropertyName}' must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("'{PropertyName}' must not contain the following characters £ # “” or spaces.");
        }
    }
}
