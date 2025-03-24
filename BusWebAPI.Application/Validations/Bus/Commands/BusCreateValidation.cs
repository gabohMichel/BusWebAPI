using BusWebAPI.Application.CustomValidations;
using BusWebAPI.Application.Services.Bus.Commands;
using FluentValidation;

namespace BusWebAPI.Application.Validations.Bus.Commands
{
    public class BusCreateValidation : AbstractValidator<BusCreateCommand>
    {
        private IsNullOrEmpty _isNullOrEmpty;
        public BusCreateValidation(ICustomValidation customValidation) 
        {
            _isNullOrEmpty = (IsNullOrEmpty)customValidation;
            RuleFor(o => o.Plates).Must(_isNullOrEmpty.IsValid).WithMessage("'{PropertyName}' is required");
            RuleFor(o => o.Capacity).GreaterThanOrEqualTo(5)
                .LessThanOrEqualTo(10);
            RuleFor(o => o.IdStatusBus).NotNull();
            RuleFor(o => o.IdCategory).NotNull();
        }
    }
}
