using BusWebAPI.Application.Services.BusSchedule.Commands;
using FluentValidation;

namespace BusWebAPI.Application.Validations.BusSchedule.Commands
{
    public class BusScheduleUpdateValidation : AbstractValidator<BusScheduleUpdateCommand>
    {
        public BusScheduleUpdateValidation() 
        {
            RuleFor(o => o.DepartureTime)
                .NotNull()
                .NotEmpty()
                .LessThan(o => o.ArrivingTime)
                .GreaterThan(DateTime.Today);
            RuleFor(o => o.ArrivingTime)
                .NotNull()
                .NotEmpty()
                .GreaterThan(o => o.DepartureTime);
            RuleFor(o => o.IsAvailable)
                .NotNull();
        }
    }
}
