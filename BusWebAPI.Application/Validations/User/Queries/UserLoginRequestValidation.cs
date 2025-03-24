using BusWebAPI.Application.CustomValidations;
using BusWebAPI.Application.Services.User.Queries;
using FluentValidation;

namespace BusWebAPI.Application.Validations.User.Queries
{
    public class UserLoginRequestValidation : AbstractValidator<UserLoginRequestQuery>
    {
        private readonly IsNullOrEmpty _isNullOrEmpty;
        public UserLoginRequestValidation(ICustomValidation customValidation) 
        {
            _isNullOrEmpty = (IsNullOrEmpty)customValidation;
            RuleFor(o => o.Username).Must(_isNullOrEmpty.IsValid).WithMessage("'{PropertyName}' is required");
            RuleFor(o => o.Password).Must(_isNullOrEmpty.IsValid).WithMessage("'{PropertyName}' is required");
        }
    }
}
