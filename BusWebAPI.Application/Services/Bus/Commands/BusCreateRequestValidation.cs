using BusWebAPI.Application.CustomValidations;
using FluentValidation;

namespace BusWebAPI.Application.Services.Bus.Commands
{
    public class BusCreateRequestValidation : AbstractValidator<BusCreateRequestCommand>
    {
        private IsNullOrEmpty _isNullOrEmpty;
        public BusCreateRequestValidation(ICustomValidation customValidation)
        {
            _isNullOrEmpty = (IsNullOrEmpty)customValidation;
            RuleFor(o => o.Plates).Must(_isNullOrEmpty.IsValid).WithMessage("Field is required")
                .MinimumLength(8)
                .MaximumLength(10);
            RuleFor(o => o.Capacity).GreaterThanOrEqualTo(5)
                .LessThanOrEqualTo(10);
            RuleFor(o => o.IdStatusBus).NotNull().NotEqual(0);
            RuleFor(o => o.IdCategory).NotNull().NotEqual(0);
        }
    }
}
