using BusWebAPI.Application.Services.BusSchedule.Commands;
using FluentValidation;

namespace BusWebAPI.Application.Validations.BusSchedule.Commands
{
    public class BusScheduleCreateValidation : AbstractValidator<BusScheduleCreateCommand>
    {
        public BusScheduleCreateValidation() 
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
            RuleFor(o => o.IdBus)
                .NotNull();
            RuleFor(o => o.IdRoute)
                .NotNull();
        }
    }
}
