using FluentValidation;

namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleUpdateValidation : AbstractValidator<BusScheduleCreateRequestCommand>
    {
        public BusScheduleUpdateValidation()
        {
            RuleFor(o => o.DepartureTime)
                .NotEmpty()
                .NotNull()
                .GreaterThan(DateTime.Now)
                .LessThan(o => o.ArrivingTime);
            RuleFor(o => o.DepartureTime)
                .NotEmpty()
                .NotNull()
                .GreaterThan(o => o.DepartureTime);
            RuleFor(o => o.IsAvailable)
                .NotEmpty()
                .NotNull();
            RuleFor(o => o.IdBus)
                .NotEmpty()
                .NotNull()
                .NotEqual(0);
            RuleFor(o => o.IdRoute)
                .NotEmpty()
                .NotNull()
                .NotEqual(0);
        }
    }
}
