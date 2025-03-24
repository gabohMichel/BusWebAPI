using BusWebAPI.Application.CustomValidations;
using BusWebAPI.Application.Services.Route.Commands;
using FluentValidation;

namespace BusWebAPI.Application.Validations.Route.Commands
{
    public class RouteCreateValidation : AbstractValidator<RouteCreateCommand>
    {
        private IsNullOrEmpty _isNullOrEmpty;
        public RouteCreateValidation(ICustomValidation customValidation) 
        {
            _isNullOrEmpty = (IsNullOrEmpty)customValidation;
            RuleFor(o => o.DeparturePoint).Must(_isNullOrEmpty.IsValid).WithMessage("'{PropertyName}' is required");
            RuleFor(o => o.ArrivingPoint).Must(_isNullOrEmpty.IsValid).WithMessage("'{PropertyName}' is required");
            RuleFor(o => o.Distance).GreaterThan(0);
        }
    }
}
